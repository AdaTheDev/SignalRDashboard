using System.Collections.Generic;

namespace SignalRDashboard.Web.Utilities
{
    public interface IDirectoryFileCache
    {
        IEnumerable<string> Files {get;}

        bool ContainsFiles { get; }
    }
}