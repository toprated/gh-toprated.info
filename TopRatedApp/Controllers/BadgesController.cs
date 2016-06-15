using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Octokit;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Common.BadgeClasses.Badges;
using TopRatedApp.Extensions;
using TopRatedApp.Helpers;
using TopRatedApp.Models;

namespace TopRatedApp.Controllers
{
    public class BadgesController : Controller
    {
        private static GitHubClient GetClient()
        {
            var c = new GitHubClient(new ProductHeaderValue("TopRated-Badges-for-GitHub-by-elv1s42"));
            var clientId = GithubApiHelper.ClientId;
            var clientSecret = GithubApiHelper.ClientSecret;
            c.Connection.Credentials = new Credentials(clientId, clientSecret);
            return c;
        }

        // GET: Language badge
        public async Task<ActionResult> GetLanguageBadge()
        {
            Response.ContentType = "image/svg+xml";

            var req = System.Web.HttpContext.Current.Request;
            var bqd = new BadgeQueryData(req);
            var c = GetClient();
            var rData = await c.GetRepoData(bqd);
            var badge = new LanguageBadge(bqd, rData.Lang);
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