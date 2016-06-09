using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class LanguageBadge : BadgeBase
    {
        public LanguageBadge(ILanguage language, string theme) : base(theme)
        {
            var langStyle = new SectionStyle(
                new FontStyle(
                    DefaultFontStyle.FontFamily,
                    DefaultFontStyle.FontSize,
                    DefaultFontStyle.FontWeight,
                    language.TextColor,
                    language.TextShadowColor),
                language.Color);

            AddSection(new Section("language", SectionType.Text, DefaultTextSectionStyle));
            AddSection(new Section(language.Name, language.SectionType, langStyle));
            SetSections(new[]
            {
                new Section("language", SectionType.Text, DefaultTextSectionStyle),
                new Section(
                    language.Name,
                    language.SectionType,
                    new SectionStyle(
                        new FontStyle(
                            DefaultFontStyle.FontFamily,
                            DefaultFontStyle.FontSize,
                            DefaultFontStyle.FontWeight,
                            language.TextColor,
                            language.TextShadowColor),
                        language.Color))
            });
        }
    }
}