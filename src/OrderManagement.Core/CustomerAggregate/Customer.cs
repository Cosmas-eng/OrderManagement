using OrderManagement.Core.CustomerAggregate.Events;

namespace OrderManagement.Core.CustomerAggregate;
public class Customer(string name) : EntityBase<Guid>, IAggregateRoot
{
  public string Name { get; private set; } = Guard.Against.NullOrWhiteSpace(name, nameof(name));
  public CustomerSegment Segment { get; private set; } = CustomerSegment.Regular;
  public DateTimeOffset RegisteredAt { get; private set; } = DateTimeOffset.UtcNow;

  public void PromotTo(CustomerSegment newSegment)
  {
    Segment = Guard.Against.Null(newSegment, nameof(newSegment));
    var domainEvent = new CustomerSegmentUpdatedEvent(Id, Segment);
    RegisterDomainEvent(domainEvent);
  }
}
