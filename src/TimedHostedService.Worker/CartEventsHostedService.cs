using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimedHostedService.Worker.Domain.CartEvents;

namespace TimedHostedService.Worker
{
    /// <summary>
    /// Based on https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio#timed-background-tasks
    /// </summary>
    public class CartEventsHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<CartEventsHostedService> _logger;
        private readonly IEventBroker _eventBroker;
        private readonly IOptions<AppSettingsOptions> _options;
        private Timer _timer;

        public CartEventsHostedService(ILogger<CartEventsHostedService> logger, IEventBroker eventBroker,
            IOptions<AppSettingsOptions> options)
        {
            _logger = logger;
            _eventBroker = eventBroker;
            _options = options;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_options.Value.PollPeriodSeconds));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation($"Run Event Broker, next run in {_options.Value.PollPeriodSeconds} seconds.");
            await _eventBroker.ProcessAsync();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
