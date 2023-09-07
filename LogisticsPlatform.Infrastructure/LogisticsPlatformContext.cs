using LogisticsPlatform.Infrastructure.EntityConfigurations;
using LogisticsPlatform.Orders;
using LogisticsPlatform.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LogisticsPlatform.Infrastructure
{
    public class LogisticsPlatformContext : DbContext
    {

        /// <summary>
        /// Default schema.
        /// </summary>
        public const string DEFAULTSCHEMA = "dbo";

        public LogisticsPlatformContext(DbContextOptions<LogisticsPlatformContext> options) : base(options) { }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<Location> VehicleLocations { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleLocationsEntityTypeConfiguration());
        }
    }
}