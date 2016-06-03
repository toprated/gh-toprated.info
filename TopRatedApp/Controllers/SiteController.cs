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
        
        // GET: Statistics
        public ActionResult Statistics()
        {
            return View("Statistics");
        }

        // GET: Top1000
        public ActionResult Top1000()
        {
            return View("Top1000");
        }

        // GET: Languages
        public ActionResult Languages()
        {
            return View("Languages");
        }

    }
}