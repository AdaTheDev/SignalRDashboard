using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SignalRDashboard.Web.Utilities
{
    public sealed class DirectoryFileCache : IDirectoryFileCache
    {
        private readonly string _directory;
        private readonly object _lockObject;
        private string[] _files;
        private bool _initialised;

        public DirectoryFileCache(string directory)
        {
            _directory = directory;
            _lockObject = new object();
        }

        public IEnumerable<string> Files
        {
            get
            {
                if (!_initialised)
                {
                    lock (_lockObject)
                    {
                        if (!_initialised)
                        {
                            _files = Directory.Exists(_directory) 
                                    ? Directory.GetFiles(_directory, "*.mp3") 
                                    : new string[] {};

                            _initialised = true;
                        }
                    }
                }
                return _files;
            }
        }

        public bool ContainsFiles => Files.Any();
    }
}