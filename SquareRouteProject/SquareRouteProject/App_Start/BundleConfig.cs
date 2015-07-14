using System.Web;
using System.Web.Optimization;

namespace SquareRouteProject.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js", 
                "~/Scripts/angular-route.js",
                "~/Scripts/lodash.min.js",
                "~/Scripts/angular-google-maps.min.js",
                "~/app/app.js", 
                "~/app/controllers/AdminController.js",
                "~/app/controllers/DispatcherController.js",
                "~/app/controllers/DriverController.js",
                "~/app/controllers/GoogleMapsController.js",
                "~/app/controllers/LoginController.js",
                "~/app/controllers/ParentController.js",
                "~/app/controllers/RegistrationController.js",
                "~/app/controllers/WelcomeController.js",
                "~/app/services/LoginService.js",
                "~/app/services/RegisterService.js",
                "~/app/services/RouteService.js",
                "~/app/services/BusStopService.js",
                "~/app/services/AccessCodeService.js"
                ));
        }
    }
}
