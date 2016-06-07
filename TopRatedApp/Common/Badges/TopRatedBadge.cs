using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class TopRatedBadge : BadgeBase
    {
        public TopRatedBadge(string percent, ILanguage language, string theme, bool expand) : base(theme)
        {
            var topRatedSectionStyle = CommonTextStyle;
            topRatedSectionStyle.BackgroundColor = Color.TopRated;
            var langStyleSection = new SectionStyle(
                new FontStyle(
                    FontStyle.FontFamily,
                    FontStyle.FontSize,
                    language.TextColor,
                    language.TextShadowColor),
                language.Color);

            if (expand)
            {
                SetSections(new[]
                {
                    new Section("toprated repo", SectionType.Text, CommonTextStyle),
                    new Section($"{language.Name} top {percent} all over GutHub", SectionType.Text, topRatedSectionStyle)
                });
            }
            else
            {
                SetSections(new[]
                {
                    //new Section(language.Name, SectionType.Text, topRatedSectionStyle),
                    new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle)
                });
            }
        }
    }
}