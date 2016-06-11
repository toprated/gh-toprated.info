using TopRatedApp.Common.BadgeClasses;

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
                default:
                    return Color.White;
            }
        }
    }
}