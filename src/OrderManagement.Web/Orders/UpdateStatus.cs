using OrderManagement.UseCases.Orders.UpdateStatus;

namespace OrderManagement.Web.Orders;

public class UpdateStatus(IMediator mediator) : Endpoint<UpdateOrderStatusRequest, DefaultOrderResponse, UpdateOrderStatusMapper>
{
  public override void Configure()
  {
    Patch(UpdateOrderStatusRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Update the status of an order.";
      s.Description = """
        Updates the status of an order to a new status.
        Valid status values are: Pending, Confirmed, Shipped, Delivered, Cancelled.

        State transitions:
        - Pending → Confirmed, Cancelled
        - Confirmed → Shipped, Cancelled
        - Shipped → Delivered
        - Delivered → (no further transitions)
        - Cancelled → (no further transitions)
        """;
      s.ExampleRequest = new UpdateOrderStatusRequest
      {
          OrderId = 1,
          Status = "Shipped"
      };
      s.Response<DefaultOrderResponse>(StatusCodes.Status200OK, "Order status was updated successfully");
      s.Responses[StatusCodes.Status404NotFound] = "Order to be updated was not found";
      s.Responses[StatusCodes.Status500InternalServerError] = "An unexpected error occurred while processing the request. Please try again later.";
    });
  }
  public override async Task HandleAsync(UpdateOrderStatusRequest request, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new UpdateOrderStatusCommand(request.OrderId, request.Status!), cancellationToken);
    if (result.IsNotFound()) await SendNotFoundAsync(cancellationToken);
    await SendMapped(result.Value, ct: cancellationToken);
  }
}
