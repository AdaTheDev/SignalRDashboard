using System;
using System.Collections.Concurrent;
using System.Linq;

namespace SignalRDashboard.Web.Utilities
{
    public sealed class SoundFilePicker : ISoundFilePicker
    {
        private readonly string _rootFolder;
        private readonly object _lockObject = new object();
        private readonly ConcurrentDictionary<string, DirectoryFileCache> _fileCaches;
         
        public SoundFilePicker(string rootFolder)
        {
            _rootFolder = rootFolder;
            if (!_rootFolder.EndsWith(@"\")) _rootFolder += @"\";
            _fileCaches = new ConcurrentDictionary<string, DirectoryFileCache>();
        }

        private string FormatSubFolder(string component, SoundFileCategory category)
        {
            return $"{component}\\{category}";
        }

        private string FormatFullFolder(string subfolder)
        {
            return $"{_rootFolder}\\{subfolder}";
        }
       
        public string GetRandomSoundFile(string component, SoundFileCategory category)
        {
            string subfolder = FormatSubFolder(component, category);
            string fullFolderPath = FormatFullFolder(subfolder);
            lock (_lockObject)
            {
                DirectoryFileCache cache = _fileCaches.GetOrAdd(subfolder, sf => new DirectoryFileCache(fullFolderPath));
                if (cache.ContainsFiles) {
                    var random = new Random();
                    return cache.Files.Skip(random.Next(0, cache.Files.Count() - 1)).FirstOrDefault();
                }
            }

            if (!component.Equals("Generic", StringComparison.CurrentCultureIgnoreCase))
                return GetRandomSoundFile("Generic", category);

            return String.Empty;
        }
    }
}