namespace OrderManagement.UseCases.Orders;
public record OrderDTO(int OrderId, Guid CustomerId, decimal Total, decimal AppliedDiscount, decimal NetTotal, string Status);
