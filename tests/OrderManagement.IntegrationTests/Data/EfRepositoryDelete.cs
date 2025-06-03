using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.IntegrationTests.Data;
public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    Guid testCustomerId = Guid.Parse("9A1E3F49-2D6D-4CF9-9BAA-1C84EF8ED724");

    // add an Order to the repository
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var order = new Order(testCustomerId, 7426251, 0);
    await repository.AddAsync(order);

    // delete the item
    await repository.DeleteAsync(order);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(), Order => Order.CustomerId == testCustomerId);
  }
}
