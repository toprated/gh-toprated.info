using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class TopRatedBadge : BadgeBase
    {
        public TopRatedBadge(string percent, ILanguage language, string theme, string size) : base(theme)
        {
            var topRatedSectionStyle = CommonTextStyle;
            topRatedSectionStyle.BackgroundColor = Color.TopRated;

            switch (size)
            {
                case "small":
                    SetSections(new[]
                    {
                        new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle)
                    });
                    break;
                case "medium":
                    SetSections(new[]
                    {
                        new Section("toprated", SectionType.Text, CommonTextStyle),
                        new Section($"{language.Name} top {percent}", SectionType.Text,
                            topRatedSectionStyle)
                    });
                    break;
                case "big":
                    SetSections(new[]
                    {
                        new Section("toprated repository", SectionType.Text, CommonTextStyle),
                        new Section($"{language.Name} top {percent} all over GutHub", SectionType.Text,
                            topRatedSectionStyle)
                    });
                    break;
                default:
                    SetSections(new[]
                    {
                        new Section("toprated", SectionType.Text, CommonTextStyle),
                        new Section($"{language.Name} top {percent}", SectionType.Text,
                            topRatedSectionStyle)
                    });
                    break;
            }
        }
    }
}