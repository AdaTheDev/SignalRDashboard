namespace SignalRDashboard.Web.Utilities
{
    public interface IFilePathToUrlConverter
    {
        string ToFullWebUrl(string path);
    }
}