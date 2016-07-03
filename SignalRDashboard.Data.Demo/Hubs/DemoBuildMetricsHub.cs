using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;
using SignalRDashboard.Data.Demo.Pollers;

namespace SignalRDashboard.Data.Demo.Hubs
{
    [HubName("demoBuildMetrics")]
    public class DemoBuildMetricsHub : PollingHub<BuildMetrics>
    {
        public DemoBuildMetricsHub() 
            : base(new TrackConnectedUsersStrategy(),
                  DemoBuildMetricsPoller.Instance)
        {
        }
    }
}
