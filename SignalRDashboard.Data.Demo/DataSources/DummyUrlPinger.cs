using System;
using SignalRDashboard.Data.Core.DataSources;

namespace SignalRDashboard.Data.Demo.DataSources
{
    public class DummyUrlPinger : IUrlPinger
    {
        private readonly Random _random = new Random();
        public bool Ping(string url)
        {
            return _random.Next(0, 10) >= 1;
        }
    }
}
