using System.IO;
using TimedHostedService.Worker.Domain.Interfaces;

namespace TimedHostedService.Worker.Infrastructure.Repositories
{
    public class WatermarkRepository : IWatermarkRepository
    {
        private readonly string _watermarkFile = "watermark.ini";
        private static readonly object _objLock = new object();

        ///<inheritdoc/>
        public long Get()
        {
            lock (_objLock) 
            {
                if (!File.Exists(_watermarkFile))
                    return 0;

                var fileValue = File.ReadAllText(_watermarkFile);

                return long.Parse(fileValue);
            }
        } 

        ///<inheritdoc/>
        public void Update(long watermark)
        {
            if (watermark <= 0)
                return;

            lock (_objLock)
            {
                File.WriteAllText(_watermarkFile, watermark.ToString());
            }
        }
    }
}
