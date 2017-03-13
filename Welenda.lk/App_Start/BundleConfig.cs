using System.Web;
using System.Web.Optimization;

namespace Welenda.lk
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/js/respond.min.js",
                      "~/Scripts/js/angular/angular.min.js",
                      "~/Scripts/js/app.js",
                      "~/Scripts/js/jquery.cookie.js",
                      "~/Scripts/js/waypoints.min.js",
                      "~/Scripts/js/modernizr.js",
                      "~/Scripts/js/bootstrap-hover-dropdown.js",
                      "~/Scripts/js/owl.carousel.min.js",
                      "~/Scripts/js/front.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/animate.min.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/style.default.css",
                      "~/Content/site.css"));
        }
    }
}
