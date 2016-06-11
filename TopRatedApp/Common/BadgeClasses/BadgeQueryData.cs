using System.Web;
using TopRatedApp.Extensions;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class BadgeQueryData
    {
        public string User;
        public string Repo;
        public string Theme;
        public string Size;
        public bool Icon;
        public IFontStyle FontStyle;

        public BadgeQueryData(HttpRequest r)
        {
            var q = r.QueryString;
            User = q["user"] ?? "user";
            Repo = q["repo"] ?? "repo";
            Theme = q["theme"] ?? "dark";
            Size = q["badgeSize"] ?? "medium";
            Icon = bool.Parse(q["icon"] ?? "true");
            FontStyle = q.GetFontStyle(Theme);
        }
    }
}