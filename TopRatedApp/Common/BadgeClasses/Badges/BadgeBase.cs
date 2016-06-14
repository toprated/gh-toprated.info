using System;
using System.Linq;
using TopRatedApp.Enums;
using TopRatedApp.Extensions;
using TopRatedApp.Helpers;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses.Badges
{
    public class BadgeBase : IBadgeBase
    {
        private readonly IFontStyle _defaultFontStyle;
        private readonly ILanguage _language;
        private Section[] _sections;

        public BadgeQueryData BadgeQueryData { get; }

        public BadgeBase(BadgeQueryData d, ILanguage language)
        {
            BadgeQueryData = d;
            _language = language;
            _defaultFontStyle = d.FontStyle;
            _sections = new Section[] { };
        }
        
        public Section[] Sections => _sections.GetFullSections(BadgeStyle);
        public double Width => Sections.Sum(s => s.W);
        public double Height => Sections.Max(s => s.H);

        public IBadgeGeometry BadgeGeometry =>
            new BadgeGeometry(
                new BadgePadding(
                    borders: 2, 
                    left: 3, 
                    right: 2, 
                    middle: 0, 
                    top: 1, 
                    bottom: 1), 
                radius: 3);

        public string BadgePath => PathHelper.GetSimpleRoundedRectPath(0, 0, Width, Height, BadgeStyle.BadgeGeometry.Radius);
        
        public IFontStyle DefaultFontStyle => _defaultFontStyle
                                              ?? new FontStyle(BadgeQueryData.Theme);

        public ISectionStyle LangSectionStyle => new SectionStyle(
            new FontStyle(
                DefaultFontStyle.FontFamily,
                DefaultFontStyle.FontSize,
                DefaultFontStyle.FontWeight,
                _language.TextColor,
                _language.TextShadowColor),
            _language.Color);

        public ISectionStyle DefaultTextSectionStyle =>
            new SectionStyle(
                DefaultFontStyle,
                ColorHelper.GetBackgroundColor(BadgeQueryData.Theme));
        
        public IBadgeStyle BadgeStyle => 
            new BadgeStyle(
                DefaultFontStyle,
                DefaultTextSectionStyle,
                BadgeGeometry,
                shadowRight: 1, shadowBottom: 1);

        public void AddIconSection(ISectionStyle style)
        {
            if (!BadgeQueryData.Icon) return;

            var height = Convert.ToInt32(BadgeStyle.DefaultFontStyle.GetTextSize("test").Height) + BadgeGeometry.Padding.Top + BadgeGeometry.Padding.Bottom;
            var width = height + BadgeGeometry.Padding.Borders;
            AddSection(new Section(SectionType.Icon, style, w: width, h: height));
        }

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