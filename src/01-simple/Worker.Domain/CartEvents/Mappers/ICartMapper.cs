using System.Collections.Generic;
using Worker.Domain.CartEvents.Events;
using Worker.Domain.Models;
using Worker.Domain.Services;

namespace Worker.Domain.CartEvents.Mappers
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