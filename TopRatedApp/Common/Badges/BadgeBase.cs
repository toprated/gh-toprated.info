using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class BadgeBase
    {
        public BadgeBase(Section[] sections, IBadgeStyle style)
        {
            Sections = sections;
            Style = style;
        }

        public Section[] Sections { get; }
        public IBadgeStyle Style { get; }
    }
}