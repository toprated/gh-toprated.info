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
        // GET: Language badge
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

        // GET: Language badge
        public async Task<ActionResult> GetTopRatedBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var user = req.QueryString["user"] ?? "user";
            var repo = req.QueryString["repo"] ?? "repo";
            var theme = req.QueryString["theme"] ?? "dark";
            var size = req.QueryString["topRatedBadgeSize"] ?? "medium";
            var icon = bool.Parse(req.QueryString["icon"] ?? "true");

            var fontWeight = req.QueryString["fontWeight"] ?? "";
            var fontSize = int.Parse(req.QueryString["fontSize"] ?? "0");
            var fontFamily = req.QueryString["fontFamily"] ?? "";
            var fontStyle = new FontStyle(theme, fontSize, fontWeight, fontFamily);
            
            var repoData = await GithubApiHelper.GetRepoData(user, repo);
            var badge = new TopRatedBadge(fontStyle, "0.05%", repoData.Lang, theme, size, icon);
            var viewModel = new TopRatedBadgeViewModel(badge);

            return View("TopRatedBadge", viewModel);
        }

        // GET: Simple language badge
        public ActionResult GetSimpleLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var lang = req.QueryString["lang"] ?? "JavaScript";
            var theme = req.QueryString["theme"] ?? "dark";
            var badge = new LanguageBadge(Languages.GetLangByName(lang), theme);
            var viewModel = new SimpleLanguageBadgeViewModel(badge);

            return View("SimpleLanguageBadge", viewModel);
        }
    }
}