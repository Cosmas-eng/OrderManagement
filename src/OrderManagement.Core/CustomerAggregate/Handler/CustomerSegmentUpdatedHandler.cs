using OrderManagement.Core.CustomerAggregate.Events;
using OrderManagement.Core.Interfaces;

namespace OrderManagement.Core.CustomerAggregate.Handler;
public class CustomerSegmentUpdatedHandler(ILogger<CustomerSegmentUpdatedHandler> logger, IEmailSender emailSender)
  : INotificationHandler<CustomerSegmentUpdatedEvent>
{
  public async Task Handle(CustomerSegmentUpdatedEvent notification, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Customer Segment updated event for {customersId}", notification.CustomerId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Customer Segment Updated",
                                     $"Customer with id {notification.CustomerId} had the segement updated to {notification.Segment.Name}.");
  }
}
