using System.Web.Optimization;

namespace DVIMonitor
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Library/JS/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Library/JS/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Library/JS/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Library/JS/bootstrap.js",
            "~/Library/JS/rss-marquee.js"));

            bundles.Add(new ScriptBundle("~/bundles/localjs").Include(
            "~/Scripts/*.js"));

            bundles.Add(new StyleBundle("~/Library/CSS/Bootstrap").Include(
            "~/Library/CSS/bootstrap.css",
            "~/Library/CSS/Toolbox.min.css"));

            bundles.Add(new StyleBundle("~/Content/CSS/MainCSS").Include(
            "~/Content/CSS/Main.min.css"));
        }
    }
}