using System.Web.Optimization;
using System.Web;


namespace SquareRouteProject.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery.dropoton.min.js", "~/Scripts/jquery.scrolly.min.js","~/Scripts/jquery.scrollex.min.js","~/Scripts/jquery.validate.min.js","~/Scripts/jquery.validate.unobtrsusive.js"));

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
                      "~/Content/style.css", "~/Content/font-awesome.css"));

        
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js", 
                "~/Scripts/angular-route.js",
                "~/Scripts/lodash.min.js",
                "~/Scripts/angular-google-maps.min.js",
                "~/app/app.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js", 
                "~/Scripts/angular-ui/ui-bootstrap.js", 
                "~/Scripts/ngxcore.js", 
                "~/Scripts/ngxdata.js", 
                "~/Scripts/ngxbuttons.js", 
                "~/Scripts/ngxscrollbar.js", 
                "~/Scripts/ngxlistbox.js",
                "~/Scripts/ngxdropdownlist.js",
                "~/Scripts/bootstrap.js", 
                "~/app/controllers/AdminController.js",
                "~/app/controllers/DispatcherController.js",
                "~/app/controllers/DriverController.js",
                "~/app/controllers/GoogleMapsController.js",
                "~/app/controllers/LoginController.js",
                "~/app/controllers/ParentController.js",
                "~/app/controllers/RegistrationController.js",
                "~/app/controllers/EmailController.js",
                "~/app/controllers/WelcomeController.js",
                "~/app/controllers/AboutUsController.js",
                "~/app/controllers/design/DropdownMenu.js",
                "~/app/controllers/design/ModalController.js",
                "~/app/services/services.js",                
                "~/app/services/EmailService.js",
                "~/app/services/LoginService.js",
                "~/app/services/RouteDriverService.js",
                "~/app/services/RouteSchoolService.js",
                "~/app/services/RouteService.js",
                "~/app/services/RouteUserService.js",
                "~/app/services/BusStopService.js",
                "~/app/services/UserService.js",
                "~/app/services/AccessCodeService.js",
                "~/app/services/AccessCodeUserService.js"
                ));
        }
    }
}
