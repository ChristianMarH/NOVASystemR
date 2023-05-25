using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Orderers;
using System.Web;
using System.Web.Optimization;

namespace NOVASystemR
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var nullBuilder = new NullBuilder();
            var nullOrderer = new NullOrderer();
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            var mainCss = new Bundle("~/css/layout");
            mainCss.Transforms.Add(new CssMinify());
            mainCss.Builder = nullBuilder;
            mainCss.Orderer = nullOrderer;
            mainCss.Include(
               "~/Assets/css/Plugins/bootstrap/bootstrap.css",
               "~/Assets/css/Plugins/animate.css/animate.css",
               "~/Assets/css/Plugins/fontawesome/css/font-awesome.css",
               //"~/Assets/fonts/Open-Sans/css/fonts.css",
               //"~/Assets/css/Plugins/metisMenu/metisMenu.css",
               //"~/Assets/css/Plugins/datepicker/datepicker.css",
               "~/Assets/sass/homer/style.min.css",
               "~/Assets/sass/ternium/style.ternium.min.css",
               //"~/Assets/css/Plugins/iCheck/skins/square/green.css",
               "~/Assets/css/Plugins/sweetalert/sweet-alert.css",
               //"~/Assets/css/Plugins/datepicker/bootstrap-datepicker3.css",
               //"~/Assets/css/Plugins/timepicker/timepicker.min.css",
               "~/Assets/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
               "~/Assets/fonts/pe-icon-7-stroke/css/helper.css",
               "~/Content/nova.css",
               "~/Content/SiteStyleRadio.css"
               );
            bundles.Add(mainCss);

            bundles.Add(new ScriptBundle("~/js/layout")
            .Include(

            "~/Assets/js/Plugins/jquery/jquery.js",
            "~/Assets/js/Plugins/jquery/jquery.unobtrusive-ajax.js",
            "~/Assets/js/Plugins/popper/popper.min.js",
            "~/Assets/js/Plugins/bootstrap/bootstrap.js",
            "~/Assets/js/Tools/common.js",
            "~/Assets/js/Plugins/metisMenu/metisMenu.js",
            "~/Assets/js/Plugins/slimScroll/jquery.slimscroll.js",
            "~/Assets/js/homer.js",
            "~/Assets/js/Plugins/sparkline/sparkline.js",
            "~/Assets/js/Plugins/iCheck/icheck.js",
            "~/Assets/js/Plugins/sweetalert/sweet-alert.min.js",
            "~/Assets/js/Plugins/datepicker/bootstrap-datepicker.js",
            "~/Assets/js/Plugins/datepicker/locales/bootstrap-datepicker.es.min.js",
            "~/Assets/js/Plugins/timepicker/timepicker.min.js",
            "~/Assets/js/Plugins/bootstrapwizard/jquery-latest.js",
            "~/Assets/js/Plugins/bootstrapwizard/jquery.bootstrap.wizard.js",
            "~/Scripts/helper.js",
            "~/Assets/js/Plugins/validate/jquery-validate.js",
            "~/Assets/js/Plugins/validate/localization/messages_es.js"));
        }
    }
}
