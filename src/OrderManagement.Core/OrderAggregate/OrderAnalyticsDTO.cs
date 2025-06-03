namespace OrderManagement.Core.OrderAggregate;
public class OrderAnalyticsDTO
{
  public int TotalOrders { get; set; }
  public decimal AverageOrderValue { get; set; }
  public double AverageFullfilmentHours { get; set; }
}
