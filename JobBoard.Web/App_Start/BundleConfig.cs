using System.Web.Optimization;

namespace JobBoard.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap.min.css", 
                "~/Content/animate.min.css", 
                "~/Content/bootstrap-select.min.css", 
                "~/Content/custom-bs.css", 
                "~/Content/custom-bs.css.map", 
                "~/Content/jquery.fancybox.min.css", 
                "~/Content/owl.carousel.min.css", 
                "~/Content/quill.snow.css", 
                "~/Content/style.css",
                "~/Content/_custom-variable.scss",
                "~/Content/_site-navbar.scss",
                "~/Content/custom-bs.scss",
                "~/Content/style.scss",
                "~/Content/fonts/icomoon/style.css",
                "~/Content/fonts/line-icons/style.css"));

            bundles.Add(new StyleBundle("~/bundles/icomoon/css").Include(
                "~/fonts/icomoon/style.css",
                "~/fonts/line-icons/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/jquery.animateNumber.min.js",
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/jquery.fancybox.min.js",
                "~/Scripts/jquery.min.js",
                "~/Scripts/jquery.waypoints.min.js",
                "~/Scripts/owl.carousel.min.js",
                 "~/Scripts/custom.js",
                "~/Scripts/isotope.pkgd.min.js",
                "~/Scripts/quill.min.js",
                 "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/bootstrap-select.min.js",
                "~/Scripts/stickyfill.min.js"));
        }
    }
}