namespace OrderManagement.Web.Orders;

public class OrderAnalyticsRequest
{
  public const string Route = "/Orders/Analytics";

  public DateTime? StartPeriod { get; set; }
  public DateTime? EndPeriod { get; set; }
}
