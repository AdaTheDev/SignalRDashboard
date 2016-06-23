using System;
using System.Text;

namespace SignalRDashboard.Data.Core.Extensions
{
    public static class TimespanExtensions
    {
        public static string ToDurationString(this TimeSpan timespan)
        {
            StringBuilder format = new StringBuilder();            
            if (timespan.Days > 0)
            {
                format.AppendFormat("{0}d ", timespan.Days);
            }

            if (timespan.Hours > 0)
            {
                format.AppendFormat("{0}h ", timespan.Hours);
            }

            format.AppendFormat("{0}m ", timespan.Minutes);
            format.AppendFormat("{0}s", timespan.Seconds);

            return format.ToString();
        }
    }
}
