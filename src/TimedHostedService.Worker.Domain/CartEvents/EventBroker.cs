using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedHostedService.Worker.Domain.CartEvents.Events;
using TimedHostedService.Worker.Domain.CartEvents.Handlers;
using TimedHostedService.Worker.Domain.CartEvents.Mappers;
using TimedHostedService.Worker.Domain.Interfaces;
using TimedHostedService.Worker.Domain.Services;

namespace TimedHostedService.Worker.Domain.CartEvents
{
    public class EventBroker : IEventBroker
    {
        private readonly ILogger<EventBroker> _logger;
        private readonly IEventFeedService _eventFeedService;
        private readonly ICartMapper _eventMapper;
        private readonly IEnumerable<IEventHandler> _eventHandlers;
        private readonly IWatermarkRepository _watermarkRepository;

        public EventBroker(ILogger<EventBroker> logger, IEventFeedService eventFeedService,
            ICartMapper cartEventMapper, IEnumerable<IEventHandler> eventHandlers,
            IWatermarkRepository watermarkRepository)
        {
            _logger = logger;
            _eventFeedService = eventFeedService;
            _eventMapper = cartEventMapper;
            _eventHandlers = eventHandlers;
            _watermarkRepository = watermarkRepository;
        }

        ///<inheritdoc/>
        public async Task ProcessAsync()
        {
            var watermark = _watermarkRepository.Get();
            
            //debug
            watermark = 1;

            var eventsDto = await _eventFeedService.GetEventsAsync(watermark);
            var events = _eventMapper.MapCartEvent(eventsDto);

            foreach (var @event in events)
            {
                await DispatchAsync(@event);
                _watermarkRepository.Update(@event.Id + 1);
            }

            if (!events.Any()) 
            {
                _logger.LogInformation($"NO NEW EVENTS FOUND. CURRENT WATERMARK IS {watermark}");
            }
        }

        private async Task DispatchAsync(CartEvent cartEvent)
        {
            if (!_eventHandlers.Any(handler => handler.IsMatch(cartEvent.EventType)))
            {
                _logger.LogError($"NO HANDLER FOUND - {cartEvent.EventType}");
            }
            else
            {
                var handlers = _eventHandlers
                    .Where(handler => handler.IsMatch(cartEvent.EventType));

                foreach (var handler in handlers)
                {
                    await handler.HandleAsync(cartEvent);
                }
            }
        }
    }
}
