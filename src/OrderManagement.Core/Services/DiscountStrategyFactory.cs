using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.Interfaces;

namespace OrderManagement.Core.Services;
public class DiscountStrategyFactory(IEnumerable<IDiscountStrategy> strategies) : IDiscountStrategyFactory
{
  private readonly Dictionary<CustomerSegment, IDiscountStrategy> _strategies = strategies.ToDictionary(s => s.Segment);
  public IDiscountStrategy GetStrategy(CustomerSegment segment)
  {
    if (!_strategies.TryGetValue(segment, out var strategy))
      throw new ArgumentException($"No strategy found for segment {segment}");

    return strategy;
  }
}
