using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CheckMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*----------------- JS Added ----------------------*/            
            ScriptBundle scriptBndl = new ScriptBundle("~/bundles/js");            
            scriptBndl.Include(
                                "~/Content/js/jQuery.js"                                
                              );
            //Add the bundle into BundleCollection
            bundles.Add(scriptBndl);            

            /*----------------- CSS Added ----------------------*/

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/css/shop-homepage.css"                
                ));
            BundleTable.EnableOptimizations = true;
        }
    }
}