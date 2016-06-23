namespace SignalRDashboard.Data.Core.Hubs
{
    public class TrackConnectedUsersStrategy : IHubUserConnectionTrackingStrategy
    {                
        public void UserConnected(string hubName)
        {
            ConnectedUsersTracker.Instance.UserConnected(hubName);
        }

        public void UserDisconnected(string hubName)
        {
            ConnectedUsersTracker.Instance.UserDisconnected(hubName);
        }

        public int GetNumberOfConnectedUsers(string hubName)
        {
            return ConnectedUsersTracker.Instance.GetNumberOfUsersConnected(hubName);
        }
    }
}