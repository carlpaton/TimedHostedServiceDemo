using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using TimedHostedService.Worker.Infrastructure.Repositories;
using TimedHostedService.Worker.Domain.Services;
using TimedHostedService.Worker.Domain.CartEvents;
using TimedHostedService.Worker.Domain.CartEvents.Mappers;
using TimedHostedService.Worker.Domain.CartEvents.Handlers;
using TimedHostedService.Worker.Domain.Interfaces;

namespace TimedHostedService.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new HostBuilder()
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole();
                })
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json");

                    builder
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddHostedService<CartEventsHostedService>();

                    services.Configure<ConnectionStringsOptions>(
                        hostBuilderContext.Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings));
                    services.Configure<AppSettingsOptions>(
                        hostBuilderContext.Configuration.GetSection(AppSettingsOptions.AppSettings));

                    services.AddHttpClient<IEventFeedService, HttpEventFeedService>();
                    services.AddTransient<IEventBroker, EventBroker>();
                    services.AddSingleton<ICartMapper, CartMapper>();

                    services.AddSingleton<IEventHandler, CartCreateEventHandler>();
                    services.AddSingleton<IEventHandler, EmailOnCartCreateEventHandler>();

                    services.AddSingleton<IWatermarkRepository, WatermarkRepository>();

                    services.AddScoped<ICartRepository, CartRepository>();
                    services.AddScoped<ICartItemRepository, CartItemRepository>();
                })
                .RunConsoleAsync();

            task.Wait();
        }
    }
}
