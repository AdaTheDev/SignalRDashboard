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
    public class DemoBuildMetricsPoller : DatasourcePoller<BuildMetrics, DemoBuildMetricsHub>
    {
        private readonly static Lazy<DemoBuildMetricsPoller> PollerInstance = new Lazy<DemoBuildMetricsPoller>(() => new DemoBuildMetricsPoller(GlobalHost.ConnectionManager.GetHubContext<DemoBuildMetricsHub>().Clients));
        private readonly IBuildMetricsProvider _provider;

        private DemoBuildMetricsPoller(IHubConnectionContext<dynamic> clients)
            : base(clients, TimeSpan.FromSeconds(15), new PollOnlyWhenUsersAreConnectedStrategy())
        {
            _provider = new DemoBuildMetricsProvider();
        }

        public static DemoBuildMetricsPoller Instance => PollerInstance.Value;

        protected override void RefreshData(BuildMetrics model)
        {
            var data = _provider.GetBuildMetrics();

            model.LastBuildDuration = data.LastBuildDuration.ToDurationString();
            model.LastBuildSucceeded = data.LastBuildSucceeded;
            model.LastBuildTime = data.LastBuildTime.ToString("dd/MM/yyyy HH:mm:ss");
            model.TotalTestCount = data.TotalTestCount;
            model.FailedTestCount = data.FailedTestCount;
            model.PassedTestCount = data.PassedTestCount;
            model.LastCommitBy = data.LastCommitBy;
            model.CodeCoverage = data.CodeCoverage;
        }

        protected override void BroadcastData(BuildMetrics model)
        {
            Clients.All.updateDemoBuildMetrics(model);
        }

    }
}