using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LogisticsPlatform.Orders;

namespace LogisticsPlatform.Infrastructure.EntityConfigurations
{ 
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Table schema
            builder.ToTable("Orders", LogisticsPlatformContext.DEFAULTSCHEMA);

            // Key
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasDefaultValueSql("NEWID()");

            // Table fields
            builder.Property(o => o.Date).HasDefaultValueSql("GETDATE()");
        }
    }
}
