using System;
using SignalRDashboard.Data.Demo.DataSources.Models;

namespace SignalRDashboard.Data.Demo.DataSources
{
    public class DemoBuildMetricsProvider : IBuildMetricsProvider
    {
        private readonly BuildMetricsData _metricsData = new BuildMetricsData();
        private readonly bool _isInitialised = false;
        private readonly string[] _awesomeDevelopers = {
            "Andy Aardvark",
            "Boris Badger",
            "Edna Elephant",
            "Frankie Frog",
            "Gordon Gopher"
        };

        public BuildMetricsData GetBuildMetrics()
        {
            var random = new Random();
            int totalTests = 1234;
            int failedTests = random.Next(1, 10) >= 3 ? 0 : random.Next(1, 10);

            if (!_isInitialised || random.Next(0, 10) > 5)
            {
                _metricsData.LastBuildTime = DateTime.Now;
                _metricsData.LastBuildDuration = TimeSpan.FromSeconds(random.Next(30, 120));
                _metricsData.LastBuildSucceeded = random.Next(1, 10) >= 4;
                _metricsData.FailedTestCount = failedTests;
                _metricsData.PassedTestCount = totalTests - failedTests;
                _metricsData.TotalTestCount = totalTests;
                _metricsData.LastCommitBy = _awesomeDevelopers[random.Next(0, 4)];
                _metricsData.CodeCoverage = random.Next(70, 90);
            }

            return _metricsData;
        }
    }
}