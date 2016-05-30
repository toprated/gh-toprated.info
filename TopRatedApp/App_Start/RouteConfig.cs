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
                name: "Badges",
                url: "Badges/LanguageBadge",
                defaults: new { controller = "Badges", action = "GetLanguageBadge" }
            );

            routes.MapRoute(
                name: "Svg",
                url: "badge",
                defaults: new { controller = "Svg", action = "GetBadge" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}

