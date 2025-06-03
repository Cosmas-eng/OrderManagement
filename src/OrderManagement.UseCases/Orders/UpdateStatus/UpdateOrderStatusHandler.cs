using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.UseCases.Orders.UpdateStatus;
public class UpdateOrderStatusHandler(IRepository<Order> repository) : ICommandHandler<UpdateOrderStatusCommand, Result<OrderDTO>>
{
    public async Task<Result<OrderDTO>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.orderId, cancellationToken);
        if (order == null) return Result.NotFound();
        var newStatus = OrderStatus.FromName(request.statusValue);
        order.UpdateStatus(newStatus);
        await repository.UpdateAsync(order, cancellationToken);
        return Result.Success(new OrderDTO(order.Id, order.CustomerId, order.Total, order.DiscountApplied, order.NetTotal, order.Status.Name));
    }
}
