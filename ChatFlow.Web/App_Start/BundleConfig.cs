using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ChatFlow.Web.App_Start {
     public class BundleConfig {
          public static void RegisterBundles(BundleCollection bundles) {
               bundles.Add(new StyleBundle("~/assets/vendors")
                    .Include("~/assets/vendors/mdi/css/materialdesignicons.min.css")
                    .Include("~/assets/vendors/css/vendor.bundle.base.css"));
               bundles.Add(new StyleBundle("~/assets/css")
                    .Include("~/assets/css/style.css"));
          }
     }
}