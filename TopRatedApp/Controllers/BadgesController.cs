using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Common.BadgeClasses.Badges;
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
            var bqd = new BadgeQueryData(req);
            var repoData = await GithubApiHelper.GetRepoData(bqd.User, bqd.Repo);
            var badge = new LanguageBadge(bqd, repoData.Lang);
            var viewModel = new LanguageBadgeViewModel(badge);

            return View("LanguageBadge", viewModel);
        }

        // GET: Language badge
        public async Task<ActionResult> GetTopRatedBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var bqd = new BadgeQueryData(req);
            var repoData = await GithubApiHelper.GetRepoData(bqd.User, bqd.Repo);

            var langTopRatedData = await GithubApiHelper.GetTopCategories(repoData.Lang);
            foreach (var c in langTopRatedData.Categories)
            {
                Debug.WriteLine($"cp: {c.PercentageString}, f: {c.From}, t: {c.To}");
            }

            var badge = new TopRatedBadge(bqd, "0.05%", repoData.Lang);
            var viewModel = new TopRatedBadgeViewModel(badge);

            return View("TopRatedBadge", viewModel);
        }

        // GET: Simple language badge
        public ActionResult GetSimpleLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var lang = req.QueryString["lang"] ?? "JavaScript";
            var bqd = new BadgeQueryData(req);
            var badge = new LanguageBadge(bqd, Languages.GetLangByName(lang));
            var viewModel = new SimpleLanguageBadgeViewModel(badge);

            return View("SimpleLanguageBadge", viewModel);
        }
    }
}