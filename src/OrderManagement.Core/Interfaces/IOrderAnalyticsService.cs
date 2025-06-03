using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Interfaces;
/// <summary>
/// Provides methods for retrieving analytics data related to orders.
/// </summary>
/// <remarks>This service is designed to analyze order data within a specified date range.  If no date range is
/// provided, the implementation may analyze all available data.</remarks>
public interface IOrderAnalyticsService
{
  Task<OrderAnalyticsDTO> GetAnalyticsAsync(DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken = default);
}
