namespace OrderManagement.Core.OrderAggregate.Evants;
/// <summary>
/// Represents an event that occurs when the status of an order is updated.
/// </summary>
/// <remarks>This event contains information about the order whose status has changed, the new status,  and the
/// associated customer. It is typically used to notify other parts of the system  about the status update.</remarks>
/// <param name="orderId"></param>
/// <param name="newStatus"></param>
/// <param name="customerId"></param>
public sealed class OrderStatusUpdatedEvent(int orderId, OrderStatus newStatus, Guid customerId) : DomainEventBase
{
  public int OrderId { get; init; } = orderId;
  public OrderStatus Status { get; init; } = newStatus;
  public Guid CustomerId { get; init; } = customerId;

}
