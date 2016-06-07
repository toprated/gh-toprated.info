using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class TopRatedBadge : BadgeBase
    {
        public TopRatedBadge(string percent, ILanguage language, string theme = "toprated") : base(theme)
        {
            SetSections(new[]
            {
                new Section($"top {percent}", SectionType.Text, CommonTextStyle),
                new Section(
                    language.Name,
                    language.SectionType,
                    new SectionStyle(
                        new FontStyle(
                            FontStyle.FontFamily,
                            FontStyle.FontSize,
                            language.TextColor,
                            language.TextShadowColor),
                        language.Color))
            });
        }
    }
}