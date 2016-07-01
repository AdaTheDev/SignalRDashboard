using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs;
using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Core.Pollers
{
    public abstract class DatasourcePoller<TModel, THub> : IDisposable, IDatasourcePoller<TModel> 
        where TModel : DashboardHubModel, new()
        where THub : DashboardHub
    {
        private readonly TimeSpan _pollingInterval;
        private readonly IPollDependingOnConnectedUsersStrategy _connectedUsersStrategy;
        private readonly string _hubName;
        private readonly Timer _timer;
        private bool _stopping;
        private readonly object _lockObject = new object();
        private bool _didRefreshDataOnLastPoll;

        protected DatasourcePoller(
            IHubConnectionContext<dynamic> clients,
            TimeSpan pollingInterval, 
            IPollDependingOnConnectedUsersStrategy connectedUsersStrategy)
        {
            var hubNameAttribute = typeof(THub).GetCustomAttributes(typeof(HubNameAttribute), true).FirstOrDefault() as HubNameAttribute;
            if (hubNameAttribute == null) throw new ArgumentNullException("HubName attribute not found on THub type: " + nameof(THub));
            _hubName = hubNameAttribute.HubName;

            _pollingInterval = pollingInterval;
            _connectedUsersStrategy = connectedUsersStrategy;            
            Clients = clients;
            Model = new TModel();
            _timer = new Timer(RefreshData, null, TimeSpan.FromSeconds(0), Timeout.InfiniteTimeSpan);
        }

        public TModel Model { get; }

        private void RefreshData(object state)
        {
            lock (_lockObject)
            {
                if (_stopping) return;

                if (_connectedUsersStrategy.CanPoll(_hubName))
                {
                    _didRefreshDataOnLastPoll = true;

                    RefreshData(Model);

                    if (Model.HasChanged)
                    {
                        BroadcastData(Model);
                    }
                }
                else
                {
                    _didRefreshDataOnLastPoll = false;
                }
                Model.ResetChangedState();
                _timer.Change(_pollingInterval, Timeout.InfiniteTimeSpan);
            }
        }

        protected abstract void RefreshData(TModel model);

        protected abstract void BroadcastData(TModel model);

        protected IHubConnectionContext<dynamic> Clients { get; private set; }

        public void Dispose()
        {
            lock (_lockObject)
            {
                if (!_stopping)
                {
                    _stopping = true;
                    _timer.Dispose();
                }
            }
        }

        public void UserConnected()
        {
            lock (_lockObject)
            {
                // When a user connects to the hub using this poller, it could be:
                // a) the first time a user has connected since the application started up
                // b) the first time a user has connected after all previous users disconnected
                // In these situations, where the  pollers only poll when users are actually connected, 
                // we will either have no initial data (a) or the data will be stale (b), so let's give 
                // the poller a little nudge to refresh its data immediately.
                if (!_didRefreshDataOnLastPoll)
                {
                    _timer.Change(TimeSpan.FromSeconds(0), Timeout.InfiniteTimeSpan);
                    _didRefreshDataOnLastPoll = true;
                }
            }
        }
    }
}
