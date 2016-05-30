using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class FontStyle : IFontStyle
    {
        public string FontFamily { get; set; }
        public string FontSize { get; set; }
        public string FontColor { get; set; }
        public string FontShadowColor { get; set; }

        public FontStyle(string fontFamily, string fontSize, string fontColor, string fontShadowColor)
        {
            FontFamily = fontFamily;
            FontSize = fontSize;
            FontColor = fontColor;
            FontShadowColor = fontShadowColor;
        }
    }
}