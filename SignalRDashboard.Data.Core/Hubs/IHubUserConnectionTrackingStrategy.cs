namespace SignalRDashboard.Data.Core.Hubs
{
    public interface IHubUserConnectionTrackingStrategy
    {
        void UserConnected(string hubName);
        void UserDisconnected(string hubName);
        int GetNumberOfConnectedUsers(string hubName);
    }
}