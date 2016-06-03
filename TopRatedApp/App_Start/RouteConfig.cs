using System.Web.Mvc;
using System.Web.Routing;

namespace TopRatedApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Badges/LanguageBadge",
                url: "Badges/LanguageBadge",
                defaults: new { controller = "Badges", action = "GetLanguageBadge" }
            );

            routes.MapRoute(
                name: "Badges/SimpleLanguageBadge",
                url: "Badges/SimpleLanguageBadge",
                defaults: new { controller = "Badges", action = "GetSimpleLanguageBadge" }
            );

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Site", action = "About" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Site", action = "Index" }
            );
        }
    }
}

