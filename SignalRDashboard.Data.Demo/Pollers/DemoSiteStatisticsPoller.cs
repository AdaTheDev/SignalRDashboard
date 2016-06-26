using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Extensions;
using SignalRDashboard.Data.Core.Pollers;
using SignalRDashboard.Data.Demo.DataSources;
using SignalRDashboard.Data.Demo.Hubs;
using SignalRDashboard.Data.Demo.Hubs.Models;

namespace SignalRDashboard.Data.Demo.Pollers
{
    public class DemoSiteStatisticsPoller : DatasourcePoller<SiteStatistics, DemoSiteStatisticsHub>
    {
        private readonly static Lazy<DemoSiteStatisticsPoller> PollerInstance = new Lazy<DemoSiteStatisticsPoller>(() => new DemoSiteStatisticsPoller(GlobalHost.ConnectionManager.GetHubContext<DemoSiteStatisticsHub>().Clients));
        private readonly ISiteAnalyticsProvider _provider;

        private DemoSiteStatisticsPoller(IHubConnectionContext<dynamic> clients)
            : base(clients, TimeSpan.FromSeconds(15), new PollOnlyWhenUsersAreConnectedStrategy())
        {
            _provider = new DemoSiteAnalyticsProvider();
        }

        public static DemoSiteStatisticsPoller Instance => PollerInstance.Value;

        protected override void RefreshData(SiteStatistics model)
        {
            var data = _provider.GetAnalyticsData();

            model.Visitors = data.Visitors;
            model.PageViews = data.PageViews;
            model.Sessions = data.Sessions;
            model.AverageSessionDuration = TimeSpan.FromSeconds(data.AverageSessionDurationSeconds).ToDurationString();
            model.PagesPerSession = Math.Round((decimal)data.PageViews/data.Sessions, 2);
            model.BounceRate = data.BounceRate;
        }

        protected override void BroadcastData(SiteStatistics model)
        {
            Clients.All.updateDemoSiteStatistics(model);
        }
    }
}
