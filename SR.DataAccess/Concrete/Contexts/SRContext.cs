using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SR.DataAccess.Concrete.Configurations;
using SR.DataAccess.Concrete.Mappings;
using SR.Entities.Concrete.DbModels;

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
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<ShowRoom> ShowRooms { get; set; }
        public DbSet<ShowRoomImages> ShowRoomImages { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your entity configurations here
            modelBuilder.ApplyConfiguration(new UserConfiguration())
                        .ApplyConfiguration(new PlanConfiguration())
                        .ApplyConfiguration(new CreditCardConfiguration())
                        .ApplyConfiguration(new ShowRoomConfiguration())
                        .ApplyConfiguration(new ShowRoomImagesConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
