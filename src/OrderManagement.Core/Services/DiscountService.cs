using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Services;
/// <summary>
/// Provides functionality to calculate discounts for orders based on customer segments.
/// </summary>
/// <remarks>This service determines the appropriate discount strategy for a given customer segment and applies it
/// to the specified order. The discount calculation is delegated to the strategy returned by the <see
/// cref="IDiscountStrategyFactory"/>.</remarks>
/// <param name="factory"></param>
public class DiscountService(IDiscountStrategyFactory factory) : IDiscountService
{
  public decimal CalculateDiscount(Order order, Customer customer)
  {
    var strategy = factory.GetStrategy(customer.Segment);
    return strategy.CalculateDiscount(order);
  }
}
