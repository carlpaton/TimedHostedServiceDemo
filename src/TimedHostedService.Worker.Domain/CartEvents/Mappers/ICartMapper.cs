using System.Collections.Generic;
using TimedHostedService.Worker.Domain.CartEvents.Events;
using TimedHostedService.Worker.Domain.Models;
using TimedHostedService.Worker.Domain.Services;

namespace TimedHostedService.Worker.Domain.CartEvents.Mappers
{
    public interface ICartMapper
    {
        /// <summary>
        /// Maps `EventDto` to domain event `CartEvent`
        /// </summary>
        /// <param name="eventDtos"></param>
        /// <returns></returns>
        IEnumerable<CartEvent> MapCartEvent(IEnumerable<EventDto> eventDtos);

        /// <summary>
        /// Maps `CartEvent` to domain model `Cart`
        /// </summary>
        /// <param name="cartEvent"></param>
        /// <returns></returns>
        Cart MapCart(CartEvent cartEvent);
    }
}