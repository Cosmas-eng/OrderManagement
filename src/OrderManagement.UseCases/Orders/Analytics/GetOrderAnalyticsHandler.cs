using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.UseCases.Orders.Analytics;
public class GetOrderAnalyticsHandler(IOrderAnalyticsService service) : IQueryHandler<GetOrderAnalyticsQuery, Result<OrderAnalyticsDTO>>
{
  public async Task<Result<OrderAnalyticsDTO>> Handle(GetOrderAnalyticsQuery request, CancellationToken cancellationToken)
  {
    var analytics = await service.GetAnalyticsAsync(request.startDate, request.endDate, cancellationToken);
    if (analytics == null)
    {
        return Result<OrderAnalyticsDTO>.Error("A problem occured while retriving order ananytics");
    }
    return Result<OrderAnalyticsDTO>.Success(analytics);
  }
}
