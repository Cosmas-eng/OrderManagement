namespace OrderManagement.UseCases.Orders.UpdateStatus;
public record UpdateOrderStatusCommand(int orderId, string statusValue) : ICommand<Result<OrderDTO>>;
