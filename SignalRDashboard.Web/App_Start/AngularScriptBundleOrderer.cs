using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace SignalRDashboard.Web
{
    public class AngularScriptBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            const string modelsBaseDirectory = "~/scripts/app/models\\";
            const string componentsBaseDirectory = "~/scripts/app/components\\";
            const string appComponentJs = "~/scripts/app/components\\AppComponent.js";
            const string dashboardCoreJs = "~/scripts/app/dashboard.js";

            var bundleFiles = files as BundleFile[] ?? files.ToArray();

            // return files in this order:
            // 1) model js files
            // 2) component js files EXCEPT the main AppComponent.js
            // 3) AppComponent.js
            // 4) core dashboard.js
            return bundleFiles.Where(file => file.IncludedVirtualPath.StartsWith(modelsBaseDirectory))
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath.StartsWith(componentsBaseDirectory) && file.IncludedVirtualPath != appComponentJs))
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath == appComponentJs)
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath == dashboardCoreJs)));
        }
    }
}