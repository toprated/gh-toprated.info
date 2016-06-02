using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class BadgeStyle : IBadgeStyle
    {
        public ISectionStyle CommonTextStyle { get; set; }
        public int PaddingBorders { get; set; }
        public int PaddingMiddle { get; set; }
        public int PaddingTop { get; set; }
        public int PaddingBottom { get; set; }
        public int Radius { get; set; }
        public double ShadowRight { get; set; }
        public double ShadowBottom { get; set; }

        public BadgeStyle(ISectionStyle commonTextStyle, int paddingBorders, int paddingMiddle, int paddingTop, int paddingBottom, int radius,
            double shadowRight, double shadowBottom)
        {
            CommonTextStyle = commonTextStyle;
            PaddingBorders = paddingBorders;
            PaddingMiddle = paddingMiddle;
            PaddingTop = paddingTop;
            PaddingBottom = paddingBottom;
            Radius = radius;
            ShadowRight = shadowRight;
            ShadowBottom = shadowBottom;
        }
    }
}