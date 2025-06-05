using OrderManagement.UseCases.Orders.ApplyDiscount;

namespace OrderManagement.Web.Orders;

public class ApplyDiscount(IMediator mediator) : Endpoint<ApplyDiscountRequest, DefaultOrderResponse, ApplyDiscountMapper>
{
  public override void Configure()
  {
    Patch(ApplyDiscountRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Apply a discount to an order.";
      s.Description = "Applies a discount to an existing order based on the customer segment and only applies when the order status is Pending";
      s.ExampleRequest = new ApplyDiscountRequest
      {
        OrderId = 1
      };
      s.Response<DefaultOrderResponse>(StatusCodes.Status200OK, "Discount was applied successfully");
      s.Responses[StatusCodes.Status404NotFound] = "Order to be updated was not found";
      s.Responses[StatusCodes.Status500InternalServerError] = "An unexpected error occurred while processing the request. Please try again later.";
    });
  }
  public override async Task HandleAsync(ApplyDiscountRequest request, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new ApplyDiscountCommand(request.OrderId), cancellationToken);
    if (result.IsNotFound()) await SendNotFoundAsync(cancellationToken);
    await SendMapped(result.Value, ct: cancellationToken);
  }
}
