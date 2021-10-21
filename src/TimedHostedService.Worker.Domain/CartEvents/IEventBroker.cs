using System.Threading.Tasks;

namespace TimedHostedService.Worker.Domain.CartEvents
{
    public interface IEventBroker
    {
        /// <summary>
        /// Orchestrates the following:
        /// 
        /// - Check watermark.
        /// - Collect new events from HTTP events feed.
        /// - Dispatch events.
        /// </summary>
        Task ProcessAsync();
    }
}
