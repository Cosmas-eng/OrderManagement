using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Services;
public class GoldDiscountStrategy : IDiscountStrategy
{
  public CustomerSegment Segment => CustomerSegment.Gold;

  public decimal CalculateDiscount(Order order) => order.Total * 0.10m;
}
