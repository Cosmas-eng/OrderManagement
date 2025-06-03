using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;
using OrderManagement.Core.Services;

namespace OrderManagement.UnitTests.Core.Services;
public class DiscountService_CalculateDiscount
{
  private readonly IDiscountStrategyFactory _discountStrategyFactory = Substitute.For<IDiscountStrategyFactory>();

  private readonly DiscountService _discountService;

  public DiscountService_CalculateDiscount()
  {
    _discountService = new DiscountService(_discountStrategyFactory);
  }

  [Fact]
  public void ReturnsZeroDiscountForRegularCustomer()
  {
    // Arrange
    var order = new Order(Guid.NewGuid(), 100, 0);
    var customer = new Customer("John Doe");
    _discountStrategyFactory.GetStrategy(customer.Segment).CalculateDiscount(order).Returns(0);
    // Act
    var discount = _discountService.CalculateDiscount(order, customer);
    // Assert
    Assert.Equal(CustomerSegment.Regular, customer.Segment);
    Assert.Equal(0, discount);
  }

  [Fact]
  public void ReturnsTenPercentDiscountForGoldCustomer()
  {
    // Arrange
    var order = new Order(Guid.NewGuid(), 100, 0);
    var customer = new Customer("Jane Doe");
    customer.PromotTo(CustomerSegment.Platinum);
    _discountStrategyFactory.GetStrategy(CustomerSegment.Platinum).CalculateDiscount(order).Returns(15);
    // Act
    var discount = _discountService.CalculateDiscount(order, customer);
    // Assert
    Assert.Equal(CustomerSegment.Platinum, customer.Segment);
    Assert.Equal(15, discount);
  }
}
