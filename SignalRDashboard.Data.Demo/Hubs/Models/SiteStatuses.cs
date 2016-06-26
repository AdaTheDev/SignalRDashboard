using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Demo.Hubs.Models
{
    public class SiteStatuses : ModelBase, IEnumerable<SiteStatus>
    {
        public override bool HasChanged { get; protected set; }

        private readonly List<SiteStatus> _sites = new List<SiteStatus>();

        public void UpdateOrAddSite(string url, string name, bool isSiteUp)
        {
            SiteStatus site = _sites.FirstOrDefault(s => s.SiteName == name);
            if (site == null)
            {
                site = new SiteStatus
                {
                    SiteName = name,
                    IsSiteUp = isSiteUp,
                    Url = url
                };
                _sites.Add(site);
                HasChanged = true;
            }
            else
            {
                site.IsSiteUp = isSiteUp;
            }

            HasChanged = HasChanged || site.HasChanged;
        }

        public override void ResetChangedState()
        {
            HasChanged = false;
            foreach (var site in _sites)
            {
                site.ResetChangedState();
            }
        }

        public SiteStatus[] GetSites => _sites.ToArray();

        public IEnumerator<SiteStatus> GetEnumerator()
        {
            return _sites.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
