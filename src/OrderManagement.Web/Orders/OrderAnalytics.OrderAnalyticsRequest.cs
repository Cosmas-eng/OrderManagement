namespace OrderManagement.Web.Orders;

public class OrderAnalyticsRequest
{
  public const string Route = "/Orders/Analytics";
  /// <summary>
  /// Gets or sets the start date and time of the period.
  /// </summary>
  public DateTime? StartPeriod { get; set; }
  /// <summary>
  /// Gets or sets the end date and time of the period.
  /// </summary>
  public DateTime? EndPeriod { get; set; }
}
