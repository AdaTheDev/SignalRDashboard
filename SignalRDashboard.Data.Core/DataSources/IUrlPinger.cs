namespace SignalRDashboard.Data.Core.DataSources
{
    public interface IUrlPinger
    {
        bool Ping(string url);
    }
}
