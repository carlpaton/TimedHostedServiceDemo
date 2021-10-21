using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TimedHostedService.Worker.Domain.CartEvents.Events;

namespace TimedHostedService.Worker.Domain.CartEvents.Handlers
{
    public class EmailOnCartCreateEventHandler : IEventHandler
    {
        private readonly ILogger<EmailOnCartCreateEventHandler> _logger;

        public EmailOnCartCreateEventHandler(ILogger<EmailOnCartCreateEventHandler> logger)
        {
            _logger = logger;
        }

        ///<inheritdoc/>
        public Task HandleAsync(CartEvent cartEvent)
        {
            _logger.LogInformation($"EMAIL SENT FOR {cartEvent.EventType}");
            return Task.CompletedTask;
        }

        ///<inheritdoc/>
        public bool IsMatch(EventType eventType)
        {
            return eventType.Equals(EventType.CART_CREATE);
        }
    }
}
