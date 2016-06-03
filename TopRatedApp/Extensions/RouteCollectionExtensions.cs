using System.Web.Mvc;
using System.Web.Routing;

namespace TopRatedApp.Extensions
{
    public static class RouteCollectionExtensions
    {
        public static void RouteSitePage(this RouteCollection rc, string pageName, string url = "", string siteControllerAction = "")
        {
            if (url.Equals("")) url = pageName;
            if (siteControllerAction.Equals("")) siteControllerAction = pageName;
            rc.MapRoute(pageName, url, new { controller = "Site", action = siteControllerAction });
        }

        public static void RouteSiteIndexPage(this RouteCollection rc, string pageName = "Default", string url = "", string siteControllerAction = "Index")
        {
            rc.MapRoute(pageName, url, new { controller = "Site", action = siteControllerAction });
        }
    }
}