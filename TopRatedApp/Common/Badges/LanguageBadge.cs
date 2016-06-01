using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class LanguageBadge : BadgeBase
    {
        public LanguageBadge(ILanguage language)
        {
            Sections = new []
            {
                new Section("language", SectionType.Text, CommonTextStyle),
                new Section(language.Name, language.SectionType, new SectionStyle(FontStyle, language.Color))
            };
        }
    }
}