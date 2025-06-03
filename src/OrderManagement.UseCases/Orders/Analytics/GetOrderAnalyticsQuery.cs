using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.UseCases.Orders.Analytics;
public record GetOrderAnalyticsQuery(DateTime? startDate, DateTime? endDate) : IQuery<Result<OrderAnalyticsDTO>>;
