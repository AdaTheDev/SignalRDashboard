using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Demo.Hubs.Models
{
    public class SiteStatistics : ModelBase
    {
        private int _visitors;
        public int Visitors
        {
            get { return _visitors; }
            set { SetProperty(ref _visitors, value); }
        }

        private int _pageViews;
        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        private int _sessions;
        public int Sessions
        {
            get { return _sessions; }
            set { SetProperty(ref _sessions, value); }
        }

        private string _averageSessionDuration;
        public string AverageSessionDuration
        {
            get { return _averageSessionDuration; }
            set { SetProperty(ref _averageSessionDuration, value); }
        }

        private decimal _pagesPerSession;
        public decimal PagesPerSession
        {
            get { return _pagesPerSession; }
            set { SetProperty(ref _pagesPerSession, value); }
        }

        private decimal _bounceRate;
        public decimal BounceRate
        {
            get { return _bounceRate; }
            set { SetProperty(ref _bounceRate, value); }
        }
    }
}
