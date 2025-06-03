using OrderManagement.Core.CustomerAggregate;

namespace OrderManagement.Core.Interfaces;
/// <summary>
/// Defines a factory for creating discount strategies based on customer segments.
/// </summary>
/// <remarks>Implementations of this interface are responsible for providing the appropriate <see
/// cref="IDiscountStrategy"/> instance for a given <see cref="CustomerSegment"/>. This allows for dynamic selection of
/// discount strategies tailored to specific customer groups.</remarks>
public interface IDiscountStrategyFactory
{
  IDiscountStrategy GetStrategy(CustomerSegment segment);
}
