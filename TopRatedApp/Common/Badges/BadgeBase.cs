using System.Linq;
using TopRatedApp.Extensions;
using TopRatedApp.Helpers;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class BadgeBase : IBadgeBase
    {
        public BadgeBase(string theme = "dark")
        {
            Theme = theme;
            _sections = new Section[] {};
        }

        public BadgeBase(Section[] sections, string theme = "dark")
        {
            Theme = theme;
            _sections = sections;
        }

        private Section[] _sections;

        public Section[] Sections => _sections.GetFullSections(Style);
        public double Width => Sections.Sum(s => s.W);
        public double Height => Sections.Max(s => s.H);
        public string BadgePath => PathHelper.GetSimpleRoundedRectPath(0, 0, Width, Height, Style.Radius);

        public string Theme { get; }
        public IFontStyle FontStyle => 
            new FontStyle(
                "DejaVu Sans,Verdana,Geneva,sans-serif", 
                11, 
                ColorHelper.GetFontColor(Theme),
                ColorHelper.GetFontShadowColor(Theme));
        public ISectionStyle CommonTextStyle =>
            new SectionStyle(
                FontStyle,
                ColorHelper.GetBackgroundColor(Theme));
        public IBadgeStyle Style => 
            new BadgeStyle(
                CommonTextStyle, 
                paddingBorders: 2, 
                paddingMiddle: 1, 
                paddingTop: 1, 
                paddingBottom: 1, 
                radius: 3,
                shadowRight: 1.2, shadowBottom: 0.9);

        public void SetSections(Section[] sections)
        {
            _sections = sections;
        }

    }
}