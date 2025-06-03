using OrderManagement.Web.Orders;


namespace OrderManagement.FunctionalTests.ApiEndpoints;
[Collection("Sequential")]
public class GetOrderAnalytics(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedOrdersAnalytics()
  {
    var result = await _client.GetAndDeserializeAsync<OrderAnalyticsResponse>(OrderAnalyticsRequest.Route);

    Assert.Equal(5, result.TotalOrders);
  }
}
