using SignalRDashboard.Data.Demo.DataSources.Models;

namespace SignalRDashboard.Data.Demo.DataSources
{
    public interface IBuildMetricsProvider
    {
        BuildMetricsData GetBuildMetrics();
    }
}
