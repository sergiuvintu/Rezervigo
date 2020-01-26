using System.Web;
using System.Web.Optimization;

namespace Rezervigo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js")); 
            
            bundles.Add(new ScriptBundle("~/bundles/select2-js").Include(
                      "~/Scripts/select2.full.js"));//select2 js  
            
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker-js").Include(
                      "~/Scripts/moment-with-locales.min.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js"
                      ));//datetime picker js
            
            bundles.Add(new ScriptBundle("~/datatables-js").Include(
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js"
                      )); // datatables js 
            bundles.Add(new ScriptBundle("~/fullcalendar-js").Include(
                      "~/Scripts/fullcalendar-main.min.js",
                      "~/Scripts/daygrid-main.min.js",
                      "~/Scripts/interaction.min.js",
                      "~/Scripts/timegrid.min.js"
                      )); // fullcalendar js

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",//bootstrap
                      "~/Content/site.css"));//custom style 
            bundles.Add(new StyleBundle("~/fontawesome").Include("~/Content/all.min.css"));//fontawesome
            bundles.Add(new StyleBundle("~/select2-css").Include("~/Content/select2.min.css"));//select2 css
            bundles.Add(new StyleBundle("~/datetimepicker-css").Include("~/Content/bootstrap-datetimepicker.min.css"));//datetimepicker css
            bundles.Add(new StyleBundle("~/datatables-css").Include("~/Content/dataTables.bootstrap.min.css"));//datatables css
            bundles.Add(new StyleBundle("~/fullcalendar-css").Include(
                    "~/Content/fullcalendar-main.min.css",
                    "~/Content/timegrid.min.css",
                    "~/Content/daygrid-main.min.css"));//fullcalendar css
        }
    }
}
