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
                        "~/DesingSource/js/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/DesingSource/js/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/js/respond.min.js",
                      "~/DesingSource/assets/angular.js",
                      "~/DesingSource/js/ng-route.js",
                      "~/Scripts/js/jquery.cookie.js",
                      "~/DesingSource/assets/angular-animate.js",
                      "~/DesingSource/assets/angular-aria.js",
                      "~/DesingSource/assets/angular-material.js",
                      "~/Scripts/js/waypoints.min.js",
                      "~/DesingSource/assets/ng-file-upload/angular-file-upload.js",
                      "~/DesingSource/assets/ng-file-upload/angular-file-upload-shim.js",
                      "~/DesingSource/assets/qr-code/raphael-2.1.0-min.j",
                      "~/DesingSource/assets/qr-code/qrcodesvg.js",
                      "~/Scripts/js/modernizr.js",
                      "~/DesingSource/assets/word-cloud/d3.v3.min.js",
                      "~/DesingSource/assets/word-cloud/d3.layout.cloud.js",
                      "~/DesingSource/assets/angular-sanitize.min.js",
                      "~/DesingSource/assets/ng-scrollbar.min.js",
                      "~/Scripts/js/bootstrap-hover-dropdown.js",
                      "~/Scripts/js/owl.carousel.min.js",
                      "~/Scripts/js/front.js",
                      "~/DesingSource/assets/fabric/fabric.js",
                      "~/DesingSource/assets/fabric/fabric.min.js",
                      "~/DesingSource/assets/fabric/fabricCanvas.js",
                      "~/DesingSource/assets/fabric/fabricConstants.js",
                      "~/DesingSource/assets/fabric/fabricDirective.js",
                      "~/DesingSource/assets/fabric/fabricDirtyStatus.js",
                      "~/DesingSource/assets/fabric/fabricUtilities.js",
                      "~/DesingSource/assets/fabric/fabricWindow.js",
                      "~/DesingSource/assets/fabric/fabric.curvedText.js",
                      "~/DesingSource/assets/fabric/fabric.customiseControls.js",
                      "~/DesingSource/assets/colorpicker/bootstrap-colorpicker-module.js",
                      "~/DesingSource/assets/pdf/jspdf.debug.js",
                      "~/DesingSource/assets/file/fileSaver.js",
                      "~/Scripts/js/app.js",
                      "~/DesingSource/js/application.js"));

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
