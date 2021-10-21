using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimedHostedService.Worker.Domain.CartEvents;

namespace TimedHostedService.Worker
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IEventBroker _eventBroker;
        private readonly IOptions<AppSettingsOptions> _options;
        private Timer _timer;

        public TimedHostedService(ILogger<TimedHostedService> logger, IEventBroker eventBroker,
            IOptions<AppSettingsOptions> options)
        {
            _logger = logger;
            _eventBroker = eventBroker;
            _options = options;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("STARTASYNC RUN");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(_options.Value.PollPeriodSeconds));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("STOPASYNC RUN");
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation($"EVENT BROKER RUNS AGAIN IN {_options.Value.PollPeriodSeconds} SECONDS.");
            await _eventBroker.ProcessAsync();
        }
    }
}
