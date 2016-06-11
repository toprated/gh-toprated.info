using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class SectionStyle : ISectionStyle
    {
        public IFontStyle FontStyle { get; set; }
        public string BackgroundColor { get; set; }

        public SectionStyle(IFontStyle fontStyle, string backgroundColor)
        {
            FontStyle = fontStyle;
            BackgroundColor = backgroundColor;
        }
    }
}