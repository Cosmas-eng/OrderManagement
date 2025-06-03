namespace OrderManagement.Web.Orders;

public class UpdateOrderStatusRequest
{
  public const string Route = "/Orders/{OrderId:int}/UpdateStatus";
  public static string BuildRoute(Guid orderId) => Route.Replace("{OrderId:int}", orderId.ToString());
  /// <summary>
  /// Gets or sets the unique identifier for the order.
  /// </summary>
  public int OrderId { get; set; }
  /// <summary>
  /// Gets or sets the current status of the operation or entity.
  /// </summary>
  public string? Status { get; set; }
}
