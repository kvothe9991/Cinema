using System.Web;
using System.Web.Optimization;

namespace Cine
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            StyleBundle(bundles);
            ScriptBundle(bundles);
        }

        public static void StyleBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                   .Include("~/Content/bootstrap.css",
                            "~/Content/jquery-ui-1.12.1.min.css"));
        }

        public static void ScriptBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
                   .Include("~/Scripts/bootstrap.js",
                            "~/Scripts/jquery-{version}.js",
                            "~/Scripts/jquery-ui-1.12.1.js"));
        }
    }
}
