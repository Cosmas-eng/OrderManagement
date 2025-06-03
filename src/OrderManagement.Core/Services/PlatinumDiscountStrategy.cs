using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Services;
public class PlatinumDiscountStrategy : IDiscountStrategy
{
  public CustomerSegment Segment => CustomerSegment.Platinum;

  public decimal CalculateDiscount(Order order) => order.Total * 0.15m;
}
