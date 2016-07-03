using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;
using SignalRDashboard.Data.Demo.Pollers;

namespace SignalRDashboard.Data.Demo.Hubs
{
    [HubName("demoSiteStatistics")]
    public class DemoSiteStatisticsHub : PollingHub<SiteStatistics>
    {
        public DemoSiteStatisticsHub() 
            : base(new TrackConnectedUsersStrategy(),
                  DemoSiteStatisticsPoller.Instance)
        {
        }
    }
}
