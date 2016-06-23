using System.Web.Optimization;

namespace SignalRDashboard.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Custom.css"));

            var bundle = new ScriptBundle("~/bundles/app")
                .IncludeDirectory("~/scripts/app/", "*.js", true);
            bundle.Orderer = new AngularScriptBundleOrderer();
            bundles.Add(bundle);
        }
    }
}
