using System.Threading.Tasks;
using System.Web.Mvc;
using TopRatedApp.Helpers;
using TopRatedApp.Models;

namespace TopRatedApp.Controllers
{
    public class BadgesController : Controller
    {
        // GET: Badge
        public async Task<ActionResult> GetLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;

            var user = req.QueryString["user"] ?? "user";
            var repo = req.QueryString["repo"] ?? "repo";
            var language = await GithubApiHelper.GetLanguageName(user, repo);
            var viewModel = new LanguageBadgeViewModel(language);

            return View("LanguageBadge", viewModel);
        }
    }
}