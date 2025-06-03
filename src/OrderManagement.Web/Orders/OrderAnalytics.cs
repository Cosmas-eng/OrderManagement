using OrderManagement.UseCases.Orders.Analytics;

namespace OrderManagement.Web.Orders;

public class OrderAnalytics(IMediator mediator) : Endpoint<OrderAnalyticsRequest, OrderAnalyticsResponse>
{
  public override void Configure()
  {
    Get(OrderAnalyticsRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.Summary = "Get order analytics";
      s.Description = "Retrieves analytics data for orders, including average order value and fulfillment hours.";
      s.Response<OrderAnalyticsResponse>(StatusCodes.Status200OK, "Returns the average order value and fulfillment hours.");
      s.Responses[StatusCodes.Status500InternalServerError] = "An unexpected error occurred while processing the request. Please try again later.";
    });
  }
  public override async Task HandleAsync(OrderAnalyticsRequest request, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(new GetOrderAnalyticsQuery(request.StartPeriod, request.EndPeriod), cancellationToken);
    if (result.IsSuccess)
    {
      var response = new OrderAnalyticsResponse
      {
        TotalOrders = result.Value.TotalOrders,
        AverageOrderValue = result.Value.AverageOrderValue,
        AveraageFullfilmentHours = result.Value.AverageFullfilmentHours
      };
      await SendOkAsync(response, cancellationToken);
    }
    else
    {
      await SendErrorsAsync(cancellation: cancellationToken);
    }
  }
}
