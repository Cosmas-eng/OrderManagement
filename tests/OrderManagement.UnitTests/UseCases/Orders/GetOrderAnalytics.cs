using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;
using OrderManagement.UseCases.Orders.Analytics;

namespace OrderManagement.UnitTests.UseCases.Orders;
public class GetOrderAnalytics
{
  private readonly IOrderAnalyticsService _service = Substitute.For<IOrderAnalyticsService>();
  private readonly GetOrderAnalyticsHandler _handler;
  public GetOrderAnalytics()
  {
    _handler = new GetOrderAnalyticsHandler(_service);
  }

  [Fact]
  public async Task Handle_ShouldReturnOrderAnalytics()
  {
    // Arrange
    var query = new GetOrderAnalyticsQuery(null, null);
    _service.GetAnalyticsAsync(Arg.Any<DateTime?>(), Arg.Any<DateTime?>(), Arg.Any<CancellationToken>())
        .Returns(new OrderAnalyticsDTO { TotalOrders = 10, AverageOrderValue = 100, AverageFullfilmentHours = 24 });
        
    // Act
    var result = await _handler.Handle(query, CancellationToken.None);
        
    // Assert
    Assert.NotNull(result);
    Assert.True(result.IsSuccess);
    Assert.IsType<OrderAnalyticsDTO>(result.Value);
  }
}
