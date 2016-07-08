using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SignalRDashboard.Web.Utilities
{
    internal static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesSafely(this Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(x => x != null);
            }
        }
    }
}