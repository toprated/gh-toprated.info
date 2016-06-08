using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class TopRatedBadge : BadgeBase
    {
        private void AddIconSection(bool icon, ISectionStyle style)
        {
            if (icon)
            {
                AddSection(new Section(SectionType.Icon, style, w: 22, h: 20));
            }
        }

        public TopRatedBadge(string percent, ILanguage language, string theme, string size, bool icon) : base(theme)
        {
            var topRatedSectionStyle = CommonTextStyle;
            topRatedSectionStyle.BackgroundColor = Color.TopRated;

            switch (size)
            {
                case "small":
                    AddIconSection(icon, topRatedSectionStyle);
                    AddSection(new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "medium":
                    AddIconSection(icon, CommonTextStyle);
                    AddSection(new Section("toprated", SectionType.Text, CommonTextStyle));
                    AddSection(new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "big":
                    AddIconSection(icon, CommonTextStyle);
                    AddSection(new Section("toprated repository", SectionType.Text, CommonTextStyle));
                    AddSection(new Section($"{language.Name} top {percent} all over GitHub", SectionType.Text, topRatedSectionStyle));
                    break;
                default:
                    AddIconSection(icon, CommonTextStyle);
                    AddSection(new Section("toprated", SectionType.Text, CommonTextStyle));
                    AddSection(new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle));
                    break;
            }

        }
    }
}