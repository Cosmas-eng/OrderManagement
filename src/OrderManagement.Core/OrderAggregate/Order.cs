using OrderManagement.Core.OrderAggregate.Evants;

namespace OrderManagement.Core.OrderAggregate;
public class Order(Guid customerId, decimal total, decimal discountApplied) : EntityBase, IAggregateRoot
{
  public Guid CustomerId { get; private set; } = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
  public decimal Total { get; private set; } = Guard.Against.NegativeOrZero(total, nameof(total));
  public decimal DiscountApplied { get; private set; } = Guard.Against.Negative(discountApplied, nameof(discountApplied));
  public decimal NetTotal => Total - DiscountApplied;
  public OrderStatus Status { get; private set; } = OrderStatus.Pending;
  public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
  public DateTimeOffset? ConfirmedAt { get; private set; }
  public DateTimeOffset? ShippedAt { get; private set; }
  public DateTimeOffset? DeliveredAt { get; private set; }
  public DateTimeOffset? UpdatedAt { get; private set; }

  private static readonly Dictionary<OrderStatus, List<OrderStatus>> _transitions = new()
  {
    [OrderStatus.Pending] = [OrderStatus.Confirmed, OrderStatus.Cancelled],
    [OrderStatus.Confirmed] = [OrderStatus.Shipped, OrderStatus.Cancelled],
    [OrderStatus.Shipped] = [OrderStatus.Delivered]
  };

  public void UpdateStatus(OrderStatus newStatus)
  {
    if (!_transitions[Status].Contains(newStatus))
        throw new InvalidOperationException($"Invalid transition from {Status} to {newStatus}");

    Status = newStatus;
    switch (newStatus)
    {
      case var status when status == OrderStatus.Confirmed:
        ConfirmedAt = DateTimeOffset.UtcNow;
        break;
      case var status when status == OrderStatus.Shipped:
        ShippedAt = DateTimeOffset.UtcNow;
        break;
      case var status when status == OrderStatus.Delivered:
        DeliveredAt = DateTimeOffset.UtcNow;
        break;
      case var status when status == OrderStatus.Cancelled:
        // No additional action needed for cancellation
        break;
    }
    UpdatedAt = DateTimeOffset.UtcNow;
    var domainEvent = new OrderStatusUpdatedEvent(Id, Status, CustomerId);
    RegisterDomainEvent(domainEvent);
  }

  public void ApplyDiscount(decimal discount)
  {
    if (Status != OrderStatus.Pending)
        throw new InvalidOperationException("Discounts can only be applied to pending orders.");

    DiscountApplied = Guard.Against.Negative(discount, nameof(discount));
    UpdatedAt = DateTimeOffset.UtcNow;
  }
}
