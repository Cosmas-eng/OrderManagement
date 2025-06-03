using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Services;
public class RegularDiscountStrategy : IDiscountStrategy
{
  public CustomerSegment Segment => CustomerSegment.Regular;

  public decimal CalculateDiscount(Order order) => 0m; // No discount for regular customers
}
