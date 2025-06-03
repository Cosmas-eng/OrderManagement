using OrderManagement.Core.CustomerAggregate;

namespace OrderManagement.Infrastructure.Data.Config;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    builder.Property(x => x.Segment).HasConversion(
        x => x.Value,
        x => CustomerSegment.FromValue(x));
  }
}
