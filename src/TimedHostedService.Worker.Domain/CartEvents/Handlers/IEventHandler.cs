using System.Threading.Tasks;
using TimedHostedService.Worker.Domain.CartEvents.Events;

namespace TimedHostedService.Worker.Domain.CartEvents.Handlers
{
    public interface IEventHandler
    {
        /// <summary>
        /// Handles the given event based on the action type in the event.
        /// </summary>
        /// <param name="cartEvent"></param>
        /// <returns></returns>
        Task HandleAsync(CartEvent cartEvent);

        /// <summary>
        /// Matches the handler from the injected collection based on EventType
        /// </summary>
        /// <param name="eventType"></param>
        /// <returns></returns>
        bool IsMatch(EventType eventType);
    }
}
