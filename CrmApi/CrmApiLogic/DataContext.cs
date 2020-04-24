using System.ComponentModel.DataAnnotations.Schema;
using CrmApiLogic.ApiModels;
using CrmApiLogic.Models;
using CrmApiLogic.Models.Customers;
using CrmApiLogic.Models.Projects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrmApiLogic
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<WorkedHour> WorkedHours { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().Property(p => p.Id).HasColumnType("char(36)");
            modelBuilder.Entity<Project>().Property(p => p.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Project>().Property(p => p.HourlyRate).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Customer>().Property(p => p.Id).HasColumnType("char(36)");

            modelBuilder.Entity<WorkedHour>().Property(p => p.Id).HasColumnType("char(36)");
            modelBuilder.Entity<WorkedHour>().Property(c => c.HourlyRate).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CrmUser>().HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("AspnetUserId");

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
