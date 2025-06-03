using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Services;
public class SilverDiscountStrategy : IDiscountStrategy
{
  public CustomerSegment Segment => CustomerSegment.Silver;

  public decimal CalculateDiscount(Order order) => order.Total * 0.05m;
}
