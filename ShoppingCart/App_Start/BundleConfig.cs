using System.Web;
using System.Web.Optimization;

namespace ShoppingCart
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/shoppingCart").Include("~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*", "~/Scripts/jquery-ui.js", "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js", "~/Scripts/knockout-{version}.js"));
            
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
