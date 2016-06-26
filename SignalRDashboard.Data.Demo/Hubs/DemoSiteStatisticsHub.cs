using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;
using SignalRDashboard.Data.Demo.Pollers;

namespace SignalRDashboard.Data.Demo.Hubs
{
    [HubName("demoSiteStatistics")]
    public class DemoSiteStatisticsHub : HubBase
    {
        private readonly DemoSiteStatisticsPoller _poller;

        public DemoSiteStatisticsHub() 
            : base(new TrackConnectedUsersStrategy())
        {
            _poller = DemoSiteStatisticsPoller.Instance;
        }

        public SiteStatistics GetDemoSiteStatistics()
        {
            return _poller.Model;
        }
    }
}
