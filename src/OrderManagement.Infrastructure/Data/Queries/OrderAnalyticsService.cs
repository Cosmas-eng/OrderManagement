using OrderManagement.Core.Interfaces;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Infrastructure.Data.Queries;
public class OrderAnalyticsService(AppDbContext appDb) : IOrderAnalyticsService
{
  public async Task<OrderAnalyticsDTO> GetAnalyticsAsync(DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken = default)
  {
    var query = appDb.Orders.AsQueryable();

    if (startDate.HasValue)
      query = query.Where(o => o.CreatedAt >= startDate.Value);

    if (endDate.HasValue)
      query = query.Where(o => o.CreatedAt <= endDate.Value);

    var totalOrders = await query.CountAsync(cancellationToken: cancellationToken);

    var avgOrderValue = totalOrders > 0 ? await query.AverageAsync(o => o.Total, cancellationToken: cancellationToken) : 0;

    var deliveredOrders = await query
        .Where(o => o.Status == OrderStatus.Delivered && o.DeliveredAt != null)
        .ToListAsync(cancellationToken: cancellationToken);

    var avgFulfillmentHours = deliveredOrders.Count != 0 ? deliveredOrders.Average(o => (o.DeliveredAt!.Value - o.CreatedAt).TotalHours) : 0;

    return new OrderAnalyticsDTO
    {
      TotalOrders = totalOrders,
      AverageOrderValue = avgOrderValue,
      AverageFullfilmentHours = avgFulfillmentHours
    };
  }
}
