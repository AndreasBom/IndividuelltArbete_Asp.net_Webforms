using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace andreasbom_3_1_IA.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JS / SCRIPT

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/jquery-1.9.0.intellisence.js",
                "~/Scripts/bootstrap.js"
                ));

            #endregion

            #region CSS / SYTLE

            bundles.Add(new StyleBundle("~/bundles/BootstrapCss").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme-css"
                ));

            #endregion
        }
    }
}