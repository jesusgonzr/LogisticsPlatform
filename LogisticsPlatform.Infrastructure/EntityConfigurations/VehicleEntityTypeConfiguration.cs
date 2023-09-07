using LogisticsPlatform.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticsPlatform.Vehicles;
using System.Diagnostics;

namespace LogisticsPlatform.Infrastructure.EntityConfigurations
{
    public class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            // Table schema
            builder.ToTable("Vehicles", LogisticsPlatformContext.DEFAULTSCHEMA);

            // Key
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasDefaultValueSql("NEWID()");

            // Table fields
            builder.Metadata.FindNavigation(nameof(Vehicle.Locations)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
