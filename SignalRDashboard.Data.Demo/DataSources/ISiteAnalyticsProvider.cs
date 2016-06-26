using SignalRDashboard.Data.Demo.DataSources.Models;

namespace SignalRDashboard.Data.Demo.DataSources
{
    public interface ISiteAnalyticsProvider
    {
        SiteAnalyticsData GetAnalyticsData();
    }
}
