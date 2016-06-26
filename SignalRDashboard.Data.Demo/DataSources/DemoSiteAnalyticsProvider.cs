using System;
using SignalRDashboard.Data.Demo.DataSources.Models;

namespace SignalRDashboard.Data.Demo.DataSources
{
    public class DemoSiteAnalyticsProvider : ISiteAnalyticsProvider
    {
        private readonly SiteAnalyticsData _dummyData = new SiteAnalyticsData();

        public SiteAnalyticsData GetAnalyticsData()
        {
            var random = new Random();

            _dummyData.Visitors += random.Next(0, 50);
            _dummyData.PageViews += random.Next(0, 100);
            _dummyData.Sessions += random.Next(0, 50);
            _dummyData.AverageSessionDurationSeconds = random.Next(30, 300);
            _dummyData.BounceRate = (decimal)Math.Round(random.NextDouble() * 100, 2);
            return _dummyData;
        }
    }
}