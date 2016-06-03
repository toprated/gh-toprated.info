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

        // GET: About
        public ActionResult About()
        {
            return View("About");
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View("Contact");
        }

        // GET: Badges
        public ActionResult Badges()
        {
            return View("Badges");
        }

        // GET: Badges
        public ActionResult Statistics()
        {
            return View("Statistics");
        }

    }
}