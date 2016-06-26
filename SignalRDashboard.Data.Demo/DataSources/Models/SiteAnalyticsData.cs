namespace SignalRDashboard.Data.Demo.DataSources.Models
{
    public class SiteAnalyticsData
    {
        public int Visitors { get; set; }
        public int Sessions { get; set; }
        public int PageViews { get; set; }
        public int AverageSessionDurationSeconds { get; set; }
        public decimal BounceRate { get; set; }
    }
}
