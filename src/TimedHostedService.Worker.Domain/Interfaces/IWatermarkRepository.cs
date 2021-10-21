namespace TimedHostedService.Worker.Domain.Interfaces
{
    public interface IWatermarkRepository
    {
        /// <summary>
        /// Selects the current watermark value
        /// Only items greater than or equal to this value will be requested from the event feed
        /// </summary>
        /// <returns></returns>
        long Get();

        /// <summary>
        /// Sets the watermark to the given value
        /// </summary>
        /// <param name="watermark"></param>
        void Update(long watermark);
    }
}
