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
            routes.MapRoute("Badges/LanguageBadge", "Badges/LanguageBadge", new { controller = "Badges", action = "GetLanguageBadge" });
            routes.MapRoute("Badges/SimpleLanguageBadge", "Badges/SimpleLanguageBadge", new { controller = "Badges", action = "GetSimpleLanguageBadge" });
            //Site pages:
            routes.RouteSitePage("Badges");
            routes.RouteSitePage("Statistics");
            routes.RouteSitePage("Top1000");
            routes.RouteSitePage("Languages");
            routes.RouteSitePage("About");
            routes.RouteSitePage("Contact");
            routes.RouteSiteIndexPage();
        }
    }
}

