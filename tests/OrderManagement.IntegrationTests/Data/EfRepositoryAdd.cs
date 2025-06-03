using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.IntegrationTests.Data;
public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsOrderAndSetsId()
  {
    Guid testCustomerId = Guid.Parse("F6C07A22-8E8B-4E57-994A-6E3C72B2631B");
    decimal testOrderTotal = 7633141;
    var repository = GetRepository();
    var order = new Order(testCustomerId, testOrderTotal, 0);

    await repository.AddAsync(order);

    var newOrder = (await repository.ListAsync()).FirstOrDefault();

    Assert.Equal(testCustomerId, newOrder?.CustomerId);
    Assert.Equal(OrderStatus.Pending, newOrder?.Status);
    Assert.Equal(testOrderTotal, newOrder?.Total);
  }
}
