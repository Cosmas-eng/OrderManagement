using System.Reflection;
using Ardalis.SharedKernel;
using OrderManagement.Core.CustomerAggregate;
using OrderManagement.UseCases.Orders.Analytics;

namespace OrderManagement.Web.Configurations;
public static class MediatrConfigs
{
  public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
  {
    var mediatRAssemblies = new[]
      {
        Assembly.GetAssembly(typeof(Customer)), // Core
        Assembly.GetAssembly(typeof(GetOrderAnalyticsHandler)) // UseCases
      };

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

    return services;
  }
}
