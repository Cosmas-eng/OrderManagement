namespace OrderManagement.UseCases.Orders.ApplyDiscount;
public record ApplyDiscountCommand(int orderId) : ICommand<Result<OrderDTO>>;
