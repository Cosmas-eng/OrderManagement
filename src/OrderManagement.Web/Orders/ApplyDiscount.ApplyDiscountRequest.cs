using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Web.Orders;

public class ApplyDiscountRequest
{
  public const string Route = "/Orders/{OrderId:int}/ApplyDiscount";
  public static string BuildRoute(Guid orderId) => Route.Replace("{OrderId:int}", orderId.ToString());
  /// <summary>
  /// Gets or sets the unique identifier for the order.
  /// </summary>
  [Required(ErrorMessage = "OrderId is required.")]
  public int OrderId { get; set; }
}
