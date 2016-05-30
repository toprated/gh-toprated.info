using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class LanguageBadge : BadgeBase
    {
        private static readonly IFontStyle FontStyle = new FontStyle("", "11", "", "");
        private static readonly ISectionStyle CommonTextStyle = new SectionStyle(FontStyle, "");
        private static readonly IBadgeStyle BadgeStyle = new BadgeStyle(CommonTextStyle, "5", "3", "4", "4");

        public LanguageBadge(Section[] sections) : base(sections, BadgeStyle)
        {

        }
    }
}