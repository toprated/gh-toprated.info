using TopRatedApp.Common;

namespace TopRatedApp.Helpers
{
    public static class ColorHelper
    {
        public static string GetBackgroundColor(string theme)
        {
            switch (theme)
            {
                case "light":
                    return Color.Silver;
                case "dark":
                    return Color.DarkGrey;
                case "toprated":
                    return Color.TopRated;
                default:
                    return Color.Silver;
            }
        }

        public static string GetFontColor(string theme)
        {
            switch (theme)
            {
                case "light":
                    return Color.Black;
                case "dark":
                    return Color.White;
                case "toprated":
                    return Color.White;
                default:
                    return Color.Black;
            }
        }

        public static string GetFontShadowColor(string theme)
        {
            switch (theme)
            {
                case "light":
                    return Color.White;
                case "dark":
                    return Color.Black;
                case "toprated":
                    return Color.Black;
                default:
                    return Color.White;
            }
        }
    }
}