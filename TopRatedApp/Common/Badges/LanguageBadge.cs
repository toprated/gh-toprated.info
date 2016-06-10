using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class LanguageBadge : BadgeBase, IBadge
    {
        public void GenerateSections(ILanguage language, BadgeQueryData bqd)
        {
            switch (bqd.Size)
            {
                case "small":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section(language.Name, language.SectionType, LangSectionStyle));
                    break;
                case "medium":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section("language", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section(language.Name, language.SectionType, LangSectionStyle));
                    break;
                case "big":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section("programming language", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section(language.Name, language.SectionType, LangSectionStyle));
                    break;
                default:
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section("language", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section(language.Name, language.SectionType, LangSectionStyle));
                    break;
            }
        }

        public LanguageBadge(BadgeQueryData bqd, ILanguage language) : base(bqd, language)
        {
            GenerateSections(language, bqd);
        }
    }
}