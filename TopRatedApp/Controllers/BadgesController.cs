using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using Octokit;
using Octokit.Internal;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Common.BadgeClasses.Badges;
using TopRatedApp.Extensions;
using TopRatedApp.Helpers;
using TopRatedApp.Models;

namespace TopRatedApp.Controllers
{
    public class BadgesController : Controller
    {
        private static async Task<GitHubClient> GetClient()
        {
            var cd = await GitHubHelper.GetClientData();
            var c = new GitHubClient(new ProductHeaderValue("TopRated-Badges-for-GitHub-by-elv1s42"));
            if (!cd.Login.Equals("") && !cd.Password.Equals(""))
            {
                c.Connection.Credentials = new Credentials(cd.Login, cd.Password);
            }
            return c;
        }

        // GET: Language badge
        public async Task<ActionResult> GetLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var bqd = new BadgeQueryData(req);
            var c = await GetClient();
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
            var repoData = await GitHubHelper.GetRepoData(bqd.User, bqd.Repo);

            var langTopRatedData = await GitHubHelper.GetTopCategories(repoData.Lang);
            foreach (var c in langTopRatedData.Categories)
            {
                Debug.WriteLine($"cp: {c.PercentageString}, f: {c.From}, t: {c.To}");
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



            var badge = new Top1000Badge(bqd, "356", repoData.Lang);
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