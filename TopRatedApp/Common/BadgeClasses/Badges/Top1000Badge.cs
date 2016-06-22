using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses.Badges
{
    public class Top1000Badge : BadgeBase, IBadge
    {
        private string _place;

        public void GenerateSections(ILanguage language, BadgeQueryData bqd)
        {
            var topRatedSectionStyle = DefaultTextSectionStyle;
            topRatedSectionStyle.BackgroundColor = Color.TopRated;
            if (_place.Equals("0"))
            {
                _place = ">1000";
            }

            switch (bqd.Size)
            {
                case "small":
                    AddIconSection(topRatedSectionStyle);
                    AddSection(new Section($"{language.Name} #{_place}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "medium":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section($"{language.Name} top 1000", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"#{_place}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "big":
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section($"GitHub {language.Name} top 1000", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"#{_place} all over GitHub", SectionType.Text, topRatedSectionStyle));
                    break;
                default:
                    AddIconSection(DefaultTextSectionStyle);
                    AddSection(new Section($"{language.Name} top 1000", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"#{_place}", SectionType.Text, topRatedSectionStyle));
                    break;
            }
        }

        public Top1000Badge(BadgeQueryData bqd, string place, ILanguage language) : base(bqd, language)
        {
            _place = place;
            GenerateSections(language, bqd);
        }
    }
}