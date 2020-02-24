using System;
using Microsoft.EntityFrameworkCore;

namespace CrmTests
{
    public class DatabaseFixture : IDisposable
    {
        CrmApiLogic.DataContext _db;

        public DatabaseFixture()
        {
            var builder = new DbContextOptionsBuilder<CrmApiLogic.DataContext>();
            builder.UseInMemoryDatabase("CRM");
            
            _db = new CrmApiLogic.DataContext(builder.Options);
        }

        public CrmApiLogic.DataContext getDb()
        {
            return _db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
