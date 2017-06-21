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
                        "~/DesingTailorSource/js/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/DesingTailorSource/js/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/js/respond.min.js",
                      "~/DesingTailorSource/assets/angular.js",
                      "~/DesingTailorSource/js/ng-route.js",
                      "~/Scripts/js/jquery.cookie.js",
                      "~/DesingTailorSource/assets/angular-animate.js",
                      "~/DesingTailorSource/assets/angular-aria.js",
                      "~/DesingTailorSource/assets/angular-material.js",
                      "~/Scripts/js/waypoints.min.js",
                      "~/DesingTailorSource/assets/ng-file-upload/angular-file-upload.js",
                      "~/DesingTailorSource/assets/ng-file-upload/angular-file-upload-shim.js",
                      "~/DesingTailorSource/assets/qr-code/raphael-2.1.0-min.j",
                      "~/DesingTailorSource/assets/qr-code/qrcodesvg.js",
                      "~/Scripts/js/modernizr.js",
                      "~/DesingTailorSource/assets/word-cloud/d3.v3.min.js",
                      "~/DesingTailorSource/assets/word-cloud/d3.layout.cloud.js",
                      "~/DesingTailorSource/assets/angular-sanitize.min.js",
                      "~/DesingTailorSource/assets/ng-scrollbar.min.js",
                      "~/Scripts/js/bootstrap-hover-dropdown.js",
                      "~/Scripts/js/owl.carousel.min.js",
                      "~/Scripts/js/front.js",
                      "~/DesingTailorSource/assets/fabric/fabric.js",
                      "~/DesingTailorSource/assets/fabric/fabric.min.js",
                      "~/DesingTailorSource/assets/fabric/fabricCanvas.js",
                      "~/DesingTailorSource/assets/fabric/fabricConstants.js",
                      "~/DesingTailorSource/assets/fabric/fabricDirective.js",
                      "~/DesingTailorSource/assets/fabric/fabricDirtyStatus.js",
                      "~/DesingTailorSource/assets/fabric/fabricUtilities.js",
                      "~/DesingTailorSource/assets/fabric/fabricWindow.js",
                      "~/DesingTailorSource/assets/fabric/fabric.curvedText.js",
                      "~/DesingTailorSource/assets/fabric/fabric.customiseControls.js",
                      "~/DesingTailorSource/assets/colorpicker/bootstrap-colorpicker-module.js",
                      "~/DesingTailorSource/assets/pdf/jspdf.debug.js",
                      "~/DesingTailorSource/assets/file/fileSaver.js",
                      "~/Scripts/js/app.js",
                      "~/DesingTailorSource/js/application.js"));

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
