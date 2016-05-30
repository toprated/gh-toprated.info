using System.Web.Mvc;

namespace TopRatedApp.Controllers
{
    public class BadgesController : Controller
    {
        // GET: Badge
        public ActionResult GetLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";
            return View("LanguageBadge");
        }
    }
}