using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimedHostedService.Worker.Domain.Services
{
    public interface IEventFeedService
    {
        /// <summary>
        /// Get a collection of events from the feed. 
        /// </summary>
        /// <param name="watermark"></param>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetEventsAsync(long watermark);
    }
}
