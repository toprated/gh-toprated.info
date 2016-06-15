using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Octokit;
using TopRatedApp.Helpers;
using TopRatedApp.Models;

namespace TopRatedApp.Controllers
{
    public class SiteController : Controller
    {
        private readonly GitHubClient _client = new GitHubClient(new ProductHeaderValue("TopRated-for-GitHub-by-elv1s42"));

        private string GetOauthLoginUrl()
        {
            var csrf = Membership.GeneratePassword(24, 1);
            Session["CSRF:State"] = csrf;
            
            var request = new OauthLoginRequest(GithubApiHelper.ClientId)
            {
                Scopes = { "user", "notifications" },
                State = csrf
            };
            var oauthLoginUrl = _client.Oauth.GetGitHubLoginUrl(request);
            return oauthLoginUrl.ToString();
        }

        public async Task<ActionResult> Authorize(string code, string state)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var expectedState = Session["CSRF:State"] as string;
                if (state != expectedState) throw new InvalidOperationException("SECURITY FAIL!");
                Session["CSRF:State"] = null;

                var token = await _client.Oauth.CreateAccessToken(
                    new OauthTokenRequest(GithubApiHelper.ClientId, GithubApiHelper.ClientSecret, code));
                Session["OAuthToken"] = token.AccessToken;
            }

            return RedirectToAction("Badges");
        }

        public async Task<ActionResult> Badges()
        {
            var accessToken = Session["OAuthToken"] as string;
            if (accessToken != null)
            {
                _client.Credentials = new Credentials(accessToken);
            }

            try
            {
                var currentClient = await _client.User.Current();
                var userName = currentClient.Name;
                var model = new BadgesViewModel(userName);

                return View("Badges", model);
            }
            catch (AuthorizationException)
            {
                return Redirect(GetOauthLoginUrl());
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View("About");
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View("Contact");
        }
        
        // GET: Statistics
        public ActionResult Statistics()
        {
            return View("Statistics");
        }

        // GET: Top1000
        public ActionResult Top1000()
        {
            return View("Top1000");
        }

        // GET: Languages
        public ActionResult Languages()
        {
            return View("Languages");
        }

    }
}