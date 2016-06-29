using SignalRDashboard.Data.Core.Hubs.Models;

namespace SignalRDashboard.Data.Demo.Hubs.Models
{
    public class BuildMetrics : ModelBase
    {
        public BuildMetrics()
        {
            LastBuildSucceeded = true;
        }

        private string _lastBuildTime;
        public string LastBuildTime
        {
            get { return _lastBuildTime; }
            set { SetProperty(ref _lastBuildTime, value); }
        }

        private string _lastBuildDuration;
        public string LastBuildDuration
        {
            get {  return _lastBuildDuration;}
            set { SetProperty(ref _lastBuildDuration, value); }
        }

        private bool _lastBuildSucceeded;
        public bool LastBuildSucceeded
        {
            get {  return _lastBuildSucceeded;}
            set { SetProperty(ref _lastBuildSucceeded, value); }
        }

        private int _totalTestCount;
        public int TotalTestCount
        {
            get { return _totalTestCount; }
            set { SetProperty(ref _totalTestCount, value); }
        }

        private int _failedTestCount;
        public int FailedTestCount
        {
            get {  return _failedTestCount;}
            set { SetProperty(ref _failedTestCount, value); }
        }

        private int _passedTestCount;
        public int PassedTestCount
        {
            get { return _passedTestCount;}
            set { SetProperty(ref _passedTestCount, value); }
        }

        private string _lastCommitBy;
        public string LastCommitBy
        {
            get { return _lastCommitBy; }
            set { SetProperty(ref _lastCommitBy, value); }
        }

        private int _codeCoverage;
        public int CodeCoverage
        {
            get { return _codeCoverage; }
            set { SetProperty(ref _codeCoverage, value); }
        }
    }
}