using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;
using SignalRDashboard.Data.Demo.Pollers;

namespace SignalRDashboard.Data.Demo.Hubs
{
    [HubName("demoBuildMetrics")]
    public class DemoBuildMetricsHub : HubBase
    {
        private readonly DemoBuildMetricsPoller _poller;

        public DemoBuildMetricsHub() 
            : base(new TrackConnectedUsersStrategy())
        {
            _poller = DemoBuildMetricsPoller.Instance;
        }

        public BuildMetrics GetDemoBuildMetrics()
        {
            return _poller.Model;
        }
    }
}
