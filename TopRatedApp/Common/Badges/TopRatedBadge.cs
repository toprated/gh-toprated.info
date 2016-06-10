using System;
using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class TopRatedBadge : BadgeBase
    {
        private void AddIconSection(bool icon, ISectionStyle style)
        {
            if (!icon) return;

            var height = Convert.ToInt32(BadgeStyle.DefaultFontStyle.GetTextSize("test").Height) + BadgeGeometry.Padding.Top + BadgeGeometry.Padding.Bottom;
            var width = height + BadgeGeometry.Padding.Borders;
            AddSection(new Section(SectionType.Icon, style, w: width, h: height));
        }

        private void GenerateSections(string percent, ILanguage language, string size, bool icon)
        {
            var topRatedSectionStyle = DefaultTextSectionStyle;
            topRatedSectionStyle.BackgroundColor = Color.TopRated;

            switch (size)
            {
                case "small":
                    AddIconSection(icon, topRatedSectionStyle);
                    AddSection(new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "medium":
                    AddIconSection(icon, DefaultTextSectionStyle);
                    AddSection(new Section("top rated", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle));
                    break;
                case "big":
                    AddIconSection(icon, DefaultTextSectionStyle);
                    AddSection(new Section("top rated repository", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"{language.Name} top {percent} all over GitHub", SectionType.Text, topRatedSectionStyle));
                    break;
                default:
                    AddIconSection(icon, DefaultTextSectionStyle);
                    AddSection(new Section("top rated", SectionType.Text, DefaultTextSectionStyle));
                    AddSection(new Section($"{language.Name} top {percent}", SectionType.Text, topRatedSectionStyle));
                    break;
            }
        }

        public TopRatedBadge(BadgeQueryData bqd, string percent, ILanguage language) : base(bqd, language)
        {
            GenerateSections(percent, language, bqd.Size, bqd.Icon);
        }
    }
}