using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class TopRatedBadge : BadgeBase, IBadge
    {
        private readonly string _percent;

        public void GenerateSections(ILanguage language, BadgeQueryData bqd)
        {
            var topRatedSectionStyle = DefaultTextSectionStyle;
            topRatedSectionStyle.BackgroundColor = Color.TopRated;

            switch (bqd.Size)
            {
                case "small":
                    AddIconSection(topRatedSectionStyle);
                    AddSection(new Section($"{language.Name} top {_percent}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "medium":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section("top rated", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"{language.Name} top {_percent}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "big":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section("top rated repository", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"{language.Name} top {_percent} all over GitHub", SectionType.Text, topRatedSectionStyle));
                    break;
                default:
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section("top rated", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"{language.Name} top {_percent}", SectionType.Text, topRatedSectionStyle));
                    break;
            }
        }

        public TopRatedBadge(BadgeQueryData bqd, string percent, ILanguage language) : base(bqd, language)
        {
            _percent = percent;
            GenerateSections(language, bqd);
        }
    }
}