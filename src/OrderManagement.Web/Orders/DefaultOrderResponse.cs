namespace OrderManagement.Web.Orders;

public class DefaultOrderResponse
{
  public int OrderId { get; set; }
  public Guid CustomerId { get; set; }
  public decimal Total { get; set; }
  public decimal AppliedDiscount { get; set; }
  public decimal NetTotal { get; set; }
  public string Status { get; set; } = string.Empty;
}
