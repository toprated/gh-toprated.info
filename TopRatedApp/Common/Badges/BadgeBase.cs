using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class BadgeBase
    {
        private string GetBackgroundColor(string theme)
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

        public BadgeBase(string theme = "")
        {
            Theme = theme.Equals("") ? "light" : theme;
            Sections = new Section[] {};
        }

        public BadgeBase(Section[] sections, string theme = "")
        {
            Theme = theme.Equals("") ? "light" : theme;
            Sections = sections;
        }

        public Section[] Sections { get; set; }

        public string Theme { get; }
        public IFontStyle FontStyle => new FontStyle(
            "DejaVu Sans,Verdana,Geneva,sans-serif", 
            "11", 
            "", 
            "");
        public ISectionStyle CommonTextStyle => new SectionStyle(
            FontStyle, 
            "");
        public IBadgeStyle Style => new BadgeStyle(CommonTextStyle, "5", "3", "4", "4");
    }
}