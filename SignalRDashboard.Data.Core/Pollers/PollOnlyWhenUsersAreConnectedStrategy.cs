namespace SignalRDashboard.Data.Core.Pollers
{
    public class PollOnlyWhenUsersAreConnectedStrategy : IPollDependingOnConnectedUsersStrategy
    {        
        public bool CanPoll(string hubName)
        {
            return ConnectedUsersTracker.Instance.GetNumberOfUsersConnected(hubName) > 0;
        }
    }
}
