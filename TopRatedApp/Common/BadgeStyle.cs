using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class BadgeStyle : IBadgeStyle
    {
        public IFontStyle DefaultFontStyle { get; set; }
        public ISectionStyle DefaultTextSectionStyle { get; set; }
        public IBadgeGeometry BadgeGeometry { get; set; }
        public double ShadowRight { get; set; }
        public double ShadowBottom { get; set; }

        public BadgeStyle(IFontStyle defaultFontStyle, ISectionStyle defaultTextSectionStyle, IBadgeGeometry geometry,
            double shadowRight, double shadowBottom)
        {
            DefaultFontStyle = defaultFontStyle;
            DefaultTextSectionStyle = defaultTextSectionStyle;
            BadgeGeometry = geometry;
            ShadowRight = shadowRight;
            ShadowBottom = shadowBottom;
        }
    }
}