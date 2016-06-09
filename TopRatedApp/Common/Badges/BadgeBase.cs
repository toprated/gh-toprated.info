using System;
using System.Linq;
using TopRatedApp.Extensions;
using TopRatedApp.Helpers;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.Badges
{
    public class BadgeBase : IBadgeBase
    {
        private readonly IFontStyle _defaultFontStyle;

        public BadgeBase(string theme)
        {
            Theme = theme;
            _sections = new Section[] { };
        }

        public BadgeBase(IFontStyle fs, string theme)
        {
            _defaultFontStyle = fs;
            Theme = theme;
            _sections = new Section[] { };
        }

        public BadgeBase(Section[] sections, string theme)
        {
            Theme = theme;
            _sections = sections;
        }

        private Section[] _sections;

        public Section[] Sections => _sections.GetFullSections(BadgeStyle);
        public double Width => Sections.Sum(s => s.W);
        public double Height => Sections.Max(s => s.H);

        public IBadgeGeometry BadgeGeometry =>
            new BadgeGeometry(
                new BadgePadding(2, 1, 1, 1), 3);

        public string BadgePath => PathHelper.GetSimpleRoundedRectPath(0, 0, Width, Height, BadgeStyle.BadgeGeometry.Radius);

        public string Theme { get; }

        public IFontStyle DefaultFontStyle => _defaultFontStyle
                                              ?? new FontStyle(Theme);

        public ISectionStyle DefaultTextSectionStyle =>
            new SectionStyle(
                DefaultFontStyle,
                ColorHelper.GetBackgroundColor(Theme));
        
        public IBadgeStyle BadgeStyle => 
            new BadgeStyle(
                DefaultFontStyle,
                DefaultTextSectionStyle,
                BadgeGeometry,
                shadowRight: 1, shadowBottom: 1);

        public void SetSections(Section[] sections)
        {
            _sections = sections;
        }

        public void AddFirstSection(Section section)
        {
            var sections = _sections;
            var size = _sections.Length;

            Array.Resize(ref _sections, size + 1);
            _sections[0] = section;
            for (var i = 1; i < size + 1; i++)
            {
                _sections[i] = sections[i - 1];
            }
        }

        public void AddSection(Section section)
        {
            var size = _sections.Length;
            Array.Resize(ref _sections, size + 1);
            _sections[size] = section;
        }

    }
}