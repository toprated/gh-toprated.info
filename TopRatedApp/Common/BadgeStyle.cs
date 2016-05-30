using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class BadgeStyle : IBadgeStyle
    {
        public ISectionStyle CommonTextStyle { get; set; }
        public string PaddingBorders { get; set; }
        public string PaddingMiddle { get; set; }
        public string PaddingTop { get; set; }
        public string PaddingBottom { get; set; }

        public BadgeStyle(ISectionStyle commonTextStyle, string paddingBorders, string paddingMiddle, string paddingTop, string paddingBottom)
        {
            CommonTextStyle = commonTextStyle;
            PaddingBorders = paddingBorders;
            PaddingMiddle = paddingMiddle;
            PaddingTop = paddingTop;
            PaddingBottom = paddingBottom;
        }
    }
}