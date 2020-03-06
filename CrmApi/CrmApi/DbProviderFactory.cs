using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace CrmApi
{
    public class DbProviderFactory
    {
        public static void GetDb(IConfiguration configuration, DbContextOptionsBuilder options)
        {
            var dbType = configuration.GetSection("DbContext:DbType").Value;
            var cnString = configuration.GetSection("DbContext:ConnectionString").Value;

            if (dbType == "sqlserver")
            {
                options.UseSqlServer(cnString, action => action.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
            }
            else if (dbType == "mysql")
            {
                options.UseMySql(cnString, mySqlOptions => mySqlOptions
                .ServerVersion(new ServerVersion(new Version(8, 0, 19), ServerType.MySql)));
            }
            else
            {
                throw new Exception("No database type configured");
            }
        }
    }
}
