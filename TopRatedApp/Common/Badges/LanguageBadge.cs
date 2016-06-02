using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class LanguageBadge : BadgeBase
    {
        public LanguageBadge(ILanguage language, string theme) : base(theme)
        {
            SetSections(new[]
            {
                new Section("language", SectionType.Text, CommonTextStyle),
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