using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;
using SignalRDashboard.Data.Demo.Pollers;

namespace SignalRDashboard.Data.Demo.Hubs
{
    [HubName("demoSiteStatus")]
    public class DemoSiteStatusHub : HubBase
    {
        private readonly DemoSiteStatusPoller _poller;

        public DemoSiteStatusHub() : base(new TrackConnectedUsersStrategy())
        {
            _poller = DemoSiteStatusPoller.Instance;
        }

        public SiteStatus[] GetDemoSiteStatus()
        {
            return _poller.Model.GetSites;
        }
    }
}
