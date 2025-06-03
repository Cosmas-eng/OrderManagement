using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Infrastructure.Data.Config;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.Property(x => x.Status).HasConversion(
        x => x.Value,
        x => OrderStatus.FromValue(x));
    builder.Property(x => x.CustomerId).IsRequired();
    builder.Property(x => x.Total).HasPrecision(DataSchemaConstants.DEFAULT_DECIMAL_PRECISION, DataSchemaConstants.DEFAULT_DECIMAL_SCALE);
    builder.Property(x => x.DiscountApplied).HasPrecision(DataSchemaConstants.DEFAULT_DECIMAL_PRECISION, DataSchemaConstants.DEFAULT_DECIMAL_SCALE);
    builder.Ignore(x => x.NetTotal);
    builder.HasIndex(x => x.CreatedAt);
    builder.HasIndex(x => x.DeliveredAt);
    builder.HasIndex(x => x.Status);
  }
}
