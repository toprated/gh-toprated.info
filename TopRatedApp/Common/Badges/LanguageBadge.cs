using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class LanguageBadge : BadgeBase
    {
        private void GenerateSections(ILanguage language)
        {
            AddSection(new Section("language", SectionType.Text, DefaultTextSectionStyle));
            AddSection(new Section(language.Name, language.SectionType, LangSectionStyle));
        }

        public LanguageBadge(BadgeQueryData bqd, ILanguage language) : base(bqd, language)
        {
            GenerateSections(language);
        }
    }
}