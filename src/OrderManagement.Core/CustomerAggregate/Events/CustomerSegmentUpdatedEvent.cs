namespace OrderManagement.Core.CustomerAggregate.Events;
/// <summary>
/// Represents an event that occurs when a customer's segment is updated.
/// </summary>
/// <remarks>This event is triggered to indicate that a customer's segment has been changed to a new value. It
/// contains the customer's unique identifier and the updated segment information.</remarks>
/// <param name="customerId"></param>
/// <param name="newSegment"></param>
public class CustomerSegmentUpdatedEvent(Guid customerId, CustomerSegment newSegment) : DomainEventBase
{
  public Guid CustomerId { get; init; } = customerId;
  public CustomerSegment Segment { get; init; } = Guard.Against.Null(newSegment, nameof(newSegment));
}
