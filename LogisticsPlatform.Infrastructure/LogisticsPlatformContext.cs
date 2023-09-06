using LogisticsPlatform.Orders;
using LogisticsPlatform.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LogisticsPlatform.Infrastructure
{
    public class LogisticsPlatformContext : DbContext
    {
        public LogisticsPlatformContext(DbContextOptions<LogisticsPlatformContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Location>  VehicleLocations { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}