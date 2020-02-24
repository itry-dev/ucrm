using System.ComponentModel.DataAnnotations.Schema;
using CrmApiLogic.ApiModels;
using CrmApiLogic.Models.Customers;
using CrmApiLogic.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrmApiLogic
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<WorkedHour> WorkedHours { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.Id).HasColumnType("char(36)");
            modelBuilder.Entity<Project>().Property(p => p.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Project>().Property(p => p.HourlyRate).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Customer>().Property(p => p.Id).HasColumnType("char(36)");

            modelBuilder.Entity<WorkedHour>().Property(p => p.Id).HasColumnType("char(36)");
            modelBuilder.Entity<WorkedHour>().Property(c => c.HourlyRate).HasColumnType("decimal(18,2)");            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging();
#endif


        }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
