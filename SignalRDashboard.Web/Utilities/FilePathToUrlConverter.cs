namespace SignalRDashboard.Web.Utilities
{
    public sealed class FilePathToUrlConverter : IFilePathToUrlConverter
    {
        private readonly string _urlRootPath;
     
        public FilePathToUrlConverter(string urlRootPath)
        {
            _urlRootPath = urlRootPath;
        }

        public string ToFullWebUrl(string path)
        {
            return path.Replace(_urlRootPath, @"~\");
        }
    }
}