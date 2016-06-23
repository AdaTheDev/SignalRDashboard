using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Core.Hubs
{
    [HubName("connectedUsers")]
    public class ConnectedUsersHub : HubBase
    {
        private readonly ConnectedUsers _stats;
        private readonly object _lockObject;

        public ConnectedUsersHub():
            base(new TrackConnectedUsersStrategy())
        {
            _stats = new ConnectedUsers();
            _lockObject = new object();
        }

        public override Task OnConnected()
        {
            var task = base.OnConnected();
            UpdateAndBroadcastStats();
            return task;
        }

        private void UpdateAndBroadcastStats()
        {
            lock (_lockObject)
            {
                _stats.NumberOfConnectedUsers = GetConnectedUsers();
                Clients.All.updateConnectedUsers(_stats);
                _stats.ResetChangedState();
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var task = base.OnDisconnected(stopCalled);
            UpdateAndBroadcastStats();
            return task;
        }        
    }    
}