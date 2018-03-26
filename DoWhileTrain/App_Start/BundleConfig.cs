using System.Web;
using System.Web.Optimization;

namespace DoWhileTrain
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Default scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //Materialize bundle
            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize.min.js"));

            //Training 'dwt' SCRIPTS
            bundles.Add(new ScriptBundle("~/bundles/Helpers").Include(
                    "~/Scripts/Site/Helpers.js"));

            bundles.Add(new ScriptBundle("~/bundles/TrainingTypes").Include(
                     "~/Scripts/Site/Helpers.js",
                     "~/Scripts/Training/Types/TrainingTypes.js"));

            bundles.Add(new ScriptBundle("~/bundles/TrainingApparatus").Include(
                    "~/Scripts/Site/Helpers.js",
                     "~/Scripts/Training/TrainingApparatus/TrainingApparatus.js"));

            bundles.Add(new ScriptBundle("~/bundles/Trainings").Include(
                     "~/Scripts/Site/Helpers.js",
                     "~/Scripts/Training/Trainings/Training.js"));

            //CSS bundle
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/site.css"));
        }
    }
}
