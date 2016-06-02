using System.Threading.Tasks;
using System.Web.Mvc;
using TopRatedApp.Common;
using TopRatedApp.Common.Badges;
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
            var theme = req.QueryString["theme"] ?? "dark";
            var languageName = await GithubApiHelper.GetLanguageName(user, repo);
            var badge = new LanguageBadge(Languages.GetLangByName(languageName), theme);
            var viewModel = new LanguageBadgeViewModel(badge);

            return View("LanguageBadge", viewModel);
        }
    }
}