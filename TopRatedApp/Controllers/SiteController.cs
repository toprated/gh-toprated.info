using System.Web.Mvc;

namespace TopRatedApp.Controllers
{
    public class SiteController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home
        public ActionResult About()
        {
            return View("About");
        }

    }
}