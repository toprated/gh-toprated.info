using System.Collections.Specialized;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Extensions
{
    public static class QueryStringExtensions
    {
        public static IFontStyle GetFontStyle(this NameValueCollection queryString, string theme)
        {
            var fontWeight = queryString["fontWeight"] ?? "";
            var fontSize = int.Parse(queryString["fontSize"] ?? "0");
            var fontFamily = queryString["fontFamily"] ?? "";
            var fontStyle = new FontStyle(theme, fontSize, fontWeight, fontFamily);

            return fontStyle;
        }
    }
}