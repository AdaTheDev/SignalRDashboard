using System;
using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Demo.Hubs.Models
{
    public class SiteStatus : DashboardHubModel
    {
        private string _siteName;
        public string SiteName
        {
            get { return _siteName; }
            set { SetProperty(ref _siteName, value); }
        }

        private bool _isSiteUp;
        public bool IsSiteUp
        {
            get { return _isSiteUp; }
            set
            {
                SetProperty(ref _isSiteUp, value);
                if (!_isSiteUp)
                {
                    LastDownTime = DateTime.Now.ToShortDateString();
                }
            }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        private string _lastDownTime;
        public string LastDownTime
        {
            get { return _lastDownTime; }
            set { SetProperty(ref _lastDownTime, value); }
        }
    }
}
