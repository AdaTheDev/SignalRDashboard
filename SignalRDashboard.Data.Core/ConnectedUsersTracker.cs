using System;
using System.Collections.Concurrent;

namespace SignalRDashboard.Data.Core
{
    public class ConnectedUsersTracker
    {
        private static readonly Lazy<ConnectedUsersTracker> TrackerInstance =
            new Lazy<ConnectedUsersTracker>(() => new ConnectedUsersTracker());
        private readonly ConcurrentDictionary<string, int> _hubConnections;

        private ConnectedUsersTracker()
        {
            _hubConnections = new ConcurrentDictionary<string, int>();
        }

        public static ConnectedUsersTracker Instance => TrackerInstance.Value;

        public void UserConnected(string hubName)
        {
            _hubConnections.AddOrUpdate(hubName, 1, (key, oldValue) => oldValue + 1);
        }

        public void UserDisconnected(string hubName)
        {
            _hubConnections.AddOrUpdate(hubName, 0, (key, oldValue) => oldValue > 0 ? oldValue - 1 : 0);
        }

        public int GetNumberOfUsersConnected(string hubName)
        {
            return _hubConnections.GetOrAdd(hubName, 0);
        }
    }    
}