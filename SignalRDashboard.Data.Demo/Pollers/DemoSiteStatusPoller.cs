using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.DataSources;
using SignalRDashboard.Data.Core.Pollers;
using SignalRDashboard.Data.Demo.DataSources;
using SignalRDashboard.Data.Demo.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;

namespace SignalRDashboard.Data.Demo.Pollers
{
    public class DemoSiteStatusPoller : DatasourcePoller<SiteStatuses, DemoSiteStatusHub>
    {
        private readonly static Lazy<DemoSiteStatusPoller> PollerInstance = new Lazy<DemoSiteStatusPoller>(() => new DemoSiteStatusPoller(GlobalHost.ConnectionManager.GetHubContext<DemoSiteStatusHub>().Clients));
        private readonly IUrlPinger _urlPinger;
        private readonly IDictionary<string, string> _dummySitesToCheck = new Dictionary<string, string> {
            {
                "http://localhost/corporate","Corporate" 
            },
            {
                "http://localhost/live", "Live"
            },
            {
                "http://localhost/beta", "Beta"
            }
        }; 

        public DemoSiteStatusPoller(IHubConnectionContext<dynamic> clients)
            : base(clients, TimeSpan.FromSeconds(15), new PollOnlyWhenUsersAreConnectedStrategy())
        {
            _urlPinger = new DummyUrlPinger();
        }

        protected override void RefreshData(SiteStatuses model)
        {            
            foreach (var url in _dummySitesToCheck.Keys)
            {
                var isSiteUp = _urlPinger.Ping(url);
                Model.UpdateOrAddSite(url, _dummySitesToCheck[url], isSiteUp);
            }
        }

        public static DemoSiteStatusPoller Instance => PollerInstance.Value;

        protected override void BroadcastData(SiteStatuses model)
        {
            Clients.All.updateDemoSiteStatus(model.GetSites);
        }
    }
}
