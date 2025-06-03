using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Services;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Email;

namespace OrderManagement.Web.Configurations;
public static class ServiceConfigs
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services, Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
  {
    services.AddInfrastructureServices(builder.Configuration, logger)
            .AddMediatrConfigs();

    services.Scan(scan => scan.FromAssembliesOf(typeof(IDiscountStrategy)) // Fix: Use typeof instead of generic type argument
                              .AddClasses(classes => classes.AssignableTo<IDiscountStrategy>())
                              .AsImplementedInterfaces()
                              .WithScopedLifetime());

    services.AddScoped<IDiscountStrategyFactory, DiscountStrategyFactory>();
    services.AddScoped<IDiscountService, DiscountService>();

    if (builder.Environment.IsDevelopment())
    {
      // Use a local test email server
      // See: https://ardalis.com/configuring-a-local-test-email-server/
      //services.AddScoped<IEmailSender, MimeKitEmailSender>();

      // Otherwise use this:
      builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

    }
    else
    {
        services.AddScoped<IEmailSender, MimeKitEmailSender>();
    }

    logger.LogInformation("{Project} services registered", "Mediatr Email Sender and Core");

    return services;
  }
}
