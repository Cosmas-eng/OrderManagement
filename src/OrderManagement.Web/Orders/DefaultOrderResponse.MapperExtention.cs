using OrderManagement.UseCases.Orders;

namespace OrderManagement.Web.Orders;

public static class MapperExtention
{
  /// <summary>
  /// Maps an <see cref="OrderDTO"/> instance to a <see cref="DefaultOrderResponse"/> object.
  /// </summary>
  /// <param name="e">The <see cref="OrderDTO"/> instance to map. Cannot be <see langword="null"/>.</param>
  /// <returns>A <see cref="DefaultOrderResponse"/> object containing the mapped values from the provided <see cref="OrderDTO"/>.</returns>
  public static DefaultOrderResponse MapResponse(this OrderDTO e) => new()
  {
    OrderId = e.OrderId,
    CustomerId = e.CustomerId,
    Total = e.Total,
    AppliedDiscount = e.AppliedDiscount,
    NetTotal = e.NetTotal,
    Status = e.Status
  };
}
