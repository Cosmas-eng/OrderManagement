using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.UnitTests.Core.OrderAggregate;
public class OrderConstructor
{
  private readonly Guid _testCustomerId = Guid.Parse("3F7A2C88-4B8E-49D0-A0E5-2D8F6E4A9CB1");
  private readonly decimal _testTotalAmount = 100.50m;
  private Order? _testOrder;

  private Order CreateOrder()
  {
    return new Order(_testCustomerId, _testTotalAmount, 0);
  }

  [Fact]
  public void InitializesOrder()
  {
    _testOrder = CreateOrder();
    Assert.Equal(_testCustomerId, _testOrder.CustomerId);
    Assert.Equal(_testTotalAmount, _testOrder.Total);
    Assert.Equal(0, _testOrder.DiscountApplied);
    Assert.Equal(OrderStatus.Pending, _testOrder.Status);
    Assert.Equal(100.50m, _testOrder.NetTotal);
  }
}
