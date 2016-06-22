using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TopRatedApp.Common;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Common.BadgeClasses.Badges;
using TopRatedApp.Extensions;
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
            var c = await GitHubHelper.GetClient();
            var rData = await c.GetRepoData(bqd);
            var badge = new LanguageBadge(bqd, rData.Lang);
            var viewModel = new LanguageBadgeViewModel(badge);

            return View("LanguageBadge", viewModel);
        }

        // GET: Top rated badge
        public async Task<ActionResult> GetTopRatedBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var bqd = new BadgeQueryData(req);
            var c = await GitHubHelper.GetClient();
            var repoData = await c.GetRepoData(bqd);

            var langTopRatedData = await GitHubHelper.GetTopCategories(repoData.Lang);
            foreach (var cat in langTopRatedData.Categories)
            {
                Debug.WriteLine($"cp: {cat.PercentageString}, f: {cat.From}, t: {cat.To}");
            }

            var badge = new TopRatedBadge(bqd, "0.05%", repoData.Lang);
            var viewModel = new TopRatedBadgeViewModel(badge);

            return View("TopRatedBadge", viewModel);
        }

        // GET: Top 1000 badge
        public async Task<ActionResult> GetTop1000Badge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var bqd = new BadgeQueryData(req);
            var repoData = await GitHubHelper.GetRepoData(bqd.User, bqd.Repo);

            var top1000 = await DataGetter.GetTop1000(repoData.Lang.ApiName);

            var place = top1000.Repos.FirstOrDefault(r => r.UserName.Equals(repoData.UserName)
                                                          && r.RepoName.Equals(repoData.RepoName))?.Place 
                                                          ?? 0;

            var badge = new Top1000Badge(bqd, place.ToString(), repoData.Lang);
            var viewModel = new Top1000BadgeViewModel(badge);

            return View("Top1000Badge", viewModel);
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