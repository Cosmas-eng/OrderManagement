using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate.Evants;

namespace OrderManagement.Core.OrderAggregate.Handlers;
public class OrderStatusUpdatedHandler(ILogger<OrderStatusUpdatedHandler> logger, IEmailSender emailSender) : INotificationHandler<OrderStatusUpdatedEvent>
{
  public async Task Handle(OrderStatusUpdatedEvent notification, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Order status updated event for {contributorId}", notification.OrderId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Order Status Updated",
                                     $"Order with id {notification.OrderId} had the status updated to {notification.Status.Name}.");
  }
}
