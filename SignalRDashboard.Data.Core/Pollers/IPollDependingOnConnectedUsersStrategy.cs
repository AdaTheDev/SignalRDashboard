namespace SignalRDashboard.Data.Core.Pollers
{
    public interface IPollDependingOnConnectedUsersStrategy
    {
        bool CanPoll(string hubName);
    }
}