using System.Web.Mvc;

namespace TopRatedApp.Controllers
{
    public class LogosController : Controller
    {
        // GET: Logos
        public ActionResult GetMainLogo()
        {
            Response.ContentType = "image/svg+xml";
            return View("MainLogo");
        }
    }
}