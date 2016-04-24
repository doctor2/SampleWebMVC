using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
               name: "ShopFilter",
               url: "filter/{filterDiscr}/{page}"//, defaults: new { controller = "Product", action = "ListWithOtherPage", FilterDiscr = 0, page = 1 }
               , defaults: new
               { controller = "Product", action = "ListWithFilter", filterDiscr = "", page = UrlParameter.Optional }
               );

            routes.MapRoute(
              name: "CatalogAll",
              url: "{page}", //{controller}/{action}/
              defaults: new { controller = "Product", action = "ListWithOtherPage", page = UrlParameter.Optional });
            //routes.MapRoute(
            //   name: "ShopFilter",
            //   url: "{ controller}/{ action}/Filter/{filterDiscr}/{page}"//, defaults: new { controller = "Product", action = "ListWithOtherPage", FilterDiscr = 0, page = 1 }
            //   , defaults: new
            //   { controller = "Product", action = "ListWithOtherPagePost", page = UrlParameter.Optional }
            //   );
            routes.MapRoute(
               name: "Navigation",
               url: "catalog/{category}/{page}", //{controller}/{action}/
               defaults: new { controller = "Product", action = "List", page = UrlParameter.Optional });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{page}",
                defaults: new { controller = "Product", action = "ListWithOtherPage", page = UrlParameter.Optional });

           

            //routes.MapRoute("Default", "{controller}/{action}",
            //    new { controller = "Product", action = "ListWithOtherPage" });
            
            //routes.MapRoute(null, "{controller}/{action}");
            //routes.MapRoute(null,
            //        "",
            //        new
            //        {
            //            controller = "Product",
            //            action = "List",
            //            category = (string)null,
            //            page = 1
            //        }
            //        );
            //routes.MapRoute(null,
            //"Page{page}",
            //new { controller = "Product", action = "List", category = (string)null },
            //new { page = @"\d+" }
            //);
            //routes.MapRoute(null,
            //"{category}",
            //new { controller = "Product", action = "List", page = 1 }
            //);
            //routes.MapRoute(null,
            //"{category}/Page{page}",
            //new { controller = "Product", action = "List" },
            //new { page = @"\d+" }
            //);

            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { Controller = "Product", action = "List" }
            //    );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //// defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
