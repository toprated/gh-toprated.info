using System.Web;

namespace TopRatedApp.Models
{
    public class LanguageBadgeViewModel
    {
        public LanguageBadgeViewModel(HttpRequest req)
        {
            var user = req.QueryString["user"] ?? "user";
            var repo = req.QueryString["repo"] ?? "repo";
            Repo = repo;
            User = user;
        }

        public string User { get; }
        public string Repo { get; }
    }
}