using System;

namespace SignalRDashboard.Data.Demo.DataSources.Models
{
    public class BuildMetricsData
    {
        public DateTime LastBuildTime { get; set; }
        public TimeSpan LastBuildDuration { get; set; }
        public bool LastBuildSucceeded { get; set; }
        public int TotalTestCount { get; set; }
        public int FailedTestCount { get; set; }
        public int PassedTestCount { get; set; }
        public string LastCommitBy { get; set; }
        public int CodeCoverage { get; set; }
    }
}