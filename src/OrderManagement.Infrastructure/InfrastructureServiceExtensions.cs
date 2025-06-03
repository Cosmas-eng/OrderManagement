using OrderManagement.Core.Interfaces;
using OrderManagement.Infrastructure.Data;
using OrderManagement.Infrastructure.Data.Queries;


namespace OrderManagement.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config, ILogger logger)
  {
    string? connectionString = config.GetConnectionString("SqliteConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
            .AddScoped<IOrderAnalyticsService, OrderAnalyticsService>();

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
