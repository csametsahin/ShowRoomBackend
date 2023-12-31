using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SR.Entities.Concrete.DbModels;
using SR.DataAccess.Concrete.Mappings;

namespace SR.DataAccess.Concrete.Contexts
{
    public class SRContext : DbContext
    {
        public SRContext()
        {
        }

        public SRContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = WebApplication.CreateBuilder();
                var connectionString = builder.Configuration.GetSection("ConnectionStrings:SRConnectionString").Value;
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString, conn => conn.CommandTimeout(180))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // allows as no-tracking
            }
        }

        #region set models
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your entity configurations here
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
