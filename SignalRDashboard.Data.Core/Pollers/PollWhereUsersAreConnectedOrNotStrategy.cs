namespace SignalRDashboard.Data.Core.Pollers
{
    public class PollWhereUsersAreConnectedOrNotStrategy : IPollDependingOnConnectedUsersStrategy
    {
        public bool CanPoll(string hubName)
        {
            return true;
        }
    }
}