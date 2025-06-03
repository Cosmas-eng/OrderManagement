using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.UseCases.Orders.ApplyDiscount;
public class ApplyDiscountHandler(IRepository<Order> orderRepo, IRepository<Customer> CustomerRepo, IDiscountService service)
  : ICommandHandler<ApplyDiscountCommand, Result<OrderDTO>>
{
    public async Task<Result<OrderDTO>> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
    {
      var order = await orderRepo.GetByIdAsync(request.orderId, cancellationToken);
      if (order == null) return Result.NotFound($"Order with the order id {request.orderId} was not found in the database");
      var customer = await CustomerRepo.GetByIdAsync(order.CustomerId, cancellationToken);
      if (customer == null) return Result.NotFound("Customer for the order is not available in the database");

      var discount = service.CalculateDiscount(order, customer);
      order.ApplyDiscount(discount);
      await orderRepo.UpdateAsync(order, cancellationToken);

      return Result.Success(new OrderDTO(order.Id, order.CustomerId, order.Total, order.DiscountApplied, order.NetTotal, order.Status.Name));
    }
}
