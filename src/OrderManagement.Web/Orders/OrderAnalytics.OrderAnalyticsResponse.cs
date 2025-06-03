namespace OrderManagement.Web.Orders;

public class OrderAnalyticsResponse
{
  public int TotalOrders { get; set; }
  public decimal AverageOrderValue { get; set; }
  public double AveraageFullfilmentHours { get; set; }
}
