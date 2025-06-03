using OrderManagement.Core.OrderAggregate;


namespace OrderManagement.IntegrationTests.Data;
public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    Guid testCustomerId = Guid.Parse("9A1E3F49-2D6D-4CF9-9BAA-1C84EF8ED724");

    // add an order to the repository
    var repository = GetRepository();
    var order = new Order(testCustomerId, 747125142, 0);

    await repository.AddAsync(order);

    // detach the item so we get a different instance
    _dbContext.Entry(order).State = EntityState.Detached;

    // fetch the item and update its title
    var newOrder = (await repository.ListAsync()).FirstOrDefault(Order => Order.CustomerId == testCustomerId);
    if (newOrder == null)
    {
      Assert.NotNull(newOrder);
      return;
    }
    Assert.NotSame(order, newOrder);
    newOrder.UpdateStatus(OrderStatus.Confirmed);

    // Update the item
    await repository.UpdateAsync(newOrder);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(Order => Order.CustomerId == testCustomerId);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(order.Status, updatedItem?.Status);
    Assert.Equal(order.Total, updatedItem?.Total);
    Assert.Equal(newOrder.Id, updatedItem?.Id);
  }
}
