using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Interfaces;
/// <summary>
/// Defines a strategy for calculating discounts based on a specific customer segment.
/// </summary>
/// <remarks>Implementations of this interface provide custom discount calculation logic tailored to a particular
/// <see cref="CustomerSegment"/>. Use this interface to apply segment-specific discounts to orders.</remarks>
public interface IDiscountStrategy
{
  CustomerSegment Segment { get; }
  decimal CalculateDiscount(Order order);
}
