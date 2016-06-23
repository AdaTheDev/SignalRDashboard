using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDashboard.Data.Core.Hubs
{
    public abstract class HubBase : Hub
    {
        private readonly IHubUserConnectionTrackingStrategy _connectionTrackingStrategy;
        private readonly string _hubName;

        protected HubBase(IHubUserConnectionTrackingStrategy connectionTrackingStrategy)
        {
            _connectionTrackingStrategy = connectionTrackingStrategy;
            HubNameAttribute hubAttribute = (HubNameAttribute)Attribute.GetCustomAttribute(GetType(), typeof(HubNameAttribute));
            _hubName = hubAttribute.HubName;
        }

        public override Task OnConnected()
        {
            _connectionTrackingStrategy.UserConnected(_hubName);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _connectionTrackingStrategy.UserDisconnected(_hubName);
            return base.OnDisconnected(stopCalled);
        }

        public int GetConnectedUsers()
        {
            return _connectionTrackingStrategy.GetNumberOfConnectedUsers(_hubName);
        }
    }
}