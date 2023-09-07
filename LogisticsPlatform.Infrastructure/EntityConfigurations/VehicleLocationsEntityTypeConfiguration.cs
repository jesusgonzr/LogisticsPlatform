using LogisticsPlatform.Vehicles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsPlatform.Infrastructure.EntityConfigurations
{
    public class VehicleLocationsEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            // Table schema
            builder.ToTable("VehiclesLocations", LogisticsPlatformContext.DEFAULTSCHEMA);

            // Key
            builder.HasKey(o => o.Id).HasName("PK_VehicleLotations_Id");
            builder.Property(o => o.Id).ValueGeneratedNever().HasDefaultValueSql("NEWID()");

            builder.Property(o => o.Date).HasDefaultValueSql("GETDATE()");
            builder.Property(o => o.Latitude).IsRequired();
            builder.Property(o => o.Longitude).IsRequired();

            builder.Property(o => o.VehiculeId).IsRequired();
        }
    }
}
