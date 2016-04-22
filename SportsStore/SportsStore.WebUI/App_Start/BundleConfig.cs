﻿using System.Web;
using System.Web.Optimization;

namespace SportsStore.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                        .Include("~/AllHtml/libs/bootstrap/bootstrap-grid-3.3.1.min.css")
                        .Include("~/AllHtml/libs/font-awesome-4.2.0/css/font-awesome.min.css")
                        .Include("~/AllHtml/libs/fancybox/jquery.fancybox.css")
                        .Include("~/AllHtml/libs/owl-carousel/owl.carousel.css")
                        .Include("~/AllHtml/libs/countdown/jquery.countdown.css")
                        .Include("~/AllHtml/css/fonts.css")
                        .Include("~/AllHtml/css/mainmy.css")
                        .Include("~/AllHtml/css/media.css"));


            bundles.Add(new ScriptBundle("~/AllHtml")
                .Include("~/AllHtml/libs/jquery/jquery-1.11.1.min.js")
                .Include("~/AllHtml/libs/jquery-mousewheel/jquery.mousewheel.min.js")
               .Include("~/AllHtml/libs/fancybox/jquery.fancybox.pack.js")
                .Include("~/AllHtml/libs/waypoints/waypoints-1.6.2.min.js")
               .Include("~/AllHtml/libs/scrollto/jquery.scrollTo.min.js")
                .Include("~/AllHtml/libs/owl-carousel/owl.carousel.min.js")
                .Include("~/AllHtml/libs/countdown/jquery.plugin.js")
                .Include("~/AllHtml/libs/countdown/jquery.countdown.min.js")
                .Include("~/AllHtml/libs/countdown/jquery.countdown-ru.js")
                .Include("~/AllHtml/libs/landing-nav/navigation.js")
                .Include("~/AllHtml/js/common.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-1.*"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //            "~/Scripts/bootstrap*"));
            //bundles.Add(new ScriptBundle("~/bundles/common").Include(
            //            "~/Scripts/common.js"));


            //bundles.Add(new StyleBundle("~/Content/css")
            //        .Include("~/Content/site.css")  /* не перепутайте порядок */
            //        .Include("~/Content/bootstrap*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //         "~/Scripts/jquery-ui-1.*"));

            //bundles.Add(new StyleBundle("~/Content/css/jqueryui")
            //       .Include("~/Content/jquery-ui-1*"));

        }
    }
}