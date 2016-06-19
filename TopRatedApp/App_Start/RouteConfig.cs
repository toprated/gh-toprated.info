using System.Web.Mvc;
using System.Web.Routing;
using TopRatedApp.Extensions;

namespace TopRatedApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Badges:
            routes.MapRoute("Badges/LanguageBadge", "Badges/LanguageBadge", 
                new { controller = "Badges", action = "GetLanguageBadge" });
            routes.MapRoute("Badges/TopRatedBadge", "Badges/TopRatedBadge", 
                new { controller = "Badges", action = "GetTopRatedBadge" });
            routes.MapRoute("Badges/Top1000Badge", "Badges/Top1000Badge", 
                new { controller = "Badges", action = "GetTop1000Badge" });
            routes.MapRoute("Badges/SimpleLanguageBadge", "Badges/SimpleLanguageBadge", 
                new { controller = "Badges", action = "GetSimpleLanguageBadge" });
            //Logos:
            routes.MapRoute("Logos/MainLogo", "Logos/MainLogo", 
                new { controller = "Logos", action = "GetMainLogo" });

            //Authorize:
            routes.MapRoute(
                name: "Authorize",
                url: "Authorize/{id}",
                defaults: new { controller = "Site", action = "Authorize", id = UrlParameter.Optional }
            );

            //Set data:
            routes.MapRoute(
                name: "SetData",
                url: "SetData",
                defaults: new { controller = "Site", action = "SetData" }
            );

            //Site pages:
            routes.RouteSitePage("Badges");
            routes.RouteSitePage("Statistics");
            routes.RouteSitePage("Top1000");
            routes.RouteSitePage("Languages");
            routes.RouteSitePage("Admin");
            routes.RouteSitePage("About");
            routes.RouteSitePage("Contact");
            routes.RouteSiteIndexPage();

        }
    }
}

