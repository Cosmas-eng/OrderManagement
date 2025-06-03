using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Infrastructure.Data;
public static class SeedData
{
  public static readonly Customer Customer1 = new("John Doe");
  public static readonly Customer Customer2 = new("Jane Smith");
  public static readonly Customer Customer3 = new("Acme Corporation");
  public static readonly Customer Customer4 = new("Global Industries");
  public static readonly Customer Customer5 = new("Tech Innovations");

  private static readonly decimal[] _orderTotals = [200000, 350000, 120000, 1500000, 3476000, 45000, 867432, 5673822, 9849370, 3451625];

  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    if (await dbContext.Orders.AnyAsync()) return; // DB has been seeded

    await PopulateCustomerTestDataAsync(dbContext);
    await PopulateOrderTestDataAsync(dbContext);
  }

  private static async Task PopulateCustomerTestDataAsync(AppDbContext dbContext)
  {
    Customer2.PromotTo(CustomerSegment.Silver);
    Customer3.PromotTo(CustomerSegment.Gold);
    Customer4.PromotTo(CustomerSegment.Platinum);
    Customer5.PromotTo(CustomerSegment.Silver);

    dbContext.Customers.AddRange([Customer1, Customer2, Customer3, Customer4, Customer5]);
    await dbContext.SaveChangesAsync();
  }

  private static async Task PopulateOrderTestDataAsync(AppDbContext dbContext)
  {
    var customers = await dbContext.Customers.AsNoTracking().ToListAsync();
    if (customers.Count == 0) return; // No customers to create orders for

    foreach (var customer in customers)
    {
      // Use Random.Shared.NextDecimal to generate a random decimal value from the orderTotals array
      var randomIndex = Random.Shared.Next(_orderTotals.Length);
      var orderTotal = _orderTotals[randomIndex];

      var order = new Order(customer.Id, orderTotal, 0);
      dbContext.Orders.Add(order);
    }

    await dbContext.SaveChangesAsync();
  }
}
