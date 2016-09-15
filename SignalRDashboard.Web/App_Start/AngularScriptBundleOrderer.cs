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
            const string dashboardComponentJs = "~/scripts/app/components/DashboardComponent.js";
            const string dashboardCoreJs = "~/scripts/app/dashboard.js";
            const string dashboardModuleJs = "~/scripts/app/DashboardModule.js";
            var bundleFiles = files as BundleFile[] ?? files.ToArray();

            // return files in this order:
            // 1) model js files
            // 2) component js files EXCEPT the main AppComponent.js
            // 3) AppComponent.js
            // 4) core dashboard.js
            return bundleFiles.Where(file => file.IncludedVirtualPath.StartsWith(modelsBaseDirectory))
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath.StartsWith(componentsBaseDirectory) && file.IncludedVirtualPath != dashboardComponentJs))
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath == dashboardComponentJs)
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath == dashboardModuleJs))
                .Union(bundleFiles.Where(file => file.IncludedVirtualPath == dashboardCoreJs)));
        }
    }
}