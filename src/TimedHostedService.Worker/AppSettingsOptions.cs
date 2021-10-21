namespace TimedHostedService.Worker
{
    public class AppSettingsOptions
    {
        public const string AppSettings = "AppSettings";

        public double PollPeriodSeconds { get; set; }
    }
}
