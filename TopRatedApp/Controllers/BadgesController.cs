using System.Web.Mvc;
using TopRatedApp.Models;

namespace TopRatedApp.Controllers
{
    public class BadgesController : Controller
    {
        // GET: Badge
        public ActionResult GetLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var viewModel = new LanguageBadgeViewModel(req);

            return View("LanguageBadge", viewModel);
        }
    }
}