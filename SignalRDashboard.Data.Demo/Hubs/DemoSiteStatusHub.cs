using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;
using SignalRDashboard.Data.Demo.Pollers;

namespace SignalRDashboard.Data.Demo.Hubs
{
    [HubName("demoSiteStatus")]
    public class DemoSiteStatusHub : PollingHub<SiteStatuses>
    {
        public DemoSiteStatusHub() : base(new TrackConnectedUsersStrategy(),
            DemoSiteStatusPoller.Instance)
        {
        }
    }
}
