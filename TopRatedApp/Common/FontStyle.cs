using System.Drawing;
using TopRatedApp.Helpers;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class FontStyle : IFontStyle
    {
        private const string DefaultFontFamily = "DejaVu Sans,Verdana,Geneva,sans-serif";
        public string FontFamily { get; set; }
        public string FontWeight { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
        public string FontShadowColor { get; set; }

        public FontStyle(string fontFamily, int fontSize, string fontWeight, string fontColor, string fontShadowColor)
        {
            FontFamily = fontFamily;
            FontSize = fontSize;
            FontColor = fontColor;
            FontShadowColor = fontShadowColor;
            FontWeight = fontWeight;
        }

        public FontStyle(string badgeTheme)
        {
            FontFamily = DefaultFontFamily;
            FontSize = 11;
            FontColor = ColorHelper.GetFontColor(badgeTheme);
            FontShadowColor = ColorHelper.GetFontShadowColor(badgeTheme);
            FontWeight = "normal";
        }

        public FontStyle(int fontSize, string fontWeight, string badgeTheme)
        {
            FontFamily = DefaultFontFamily;
            FontSize = fontSize;
            FontColor = ColorHelper.GetFontColor(badgeTheme);
            FontShadowColor = ColorHelper.GetFontShadowColor(badgeTheme);
            FontWeight = fontWeight;
        }

        public SizeF GetTextSize(string text)
        {
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font(FontFamily, FontSize);//, GraphicsUnit.Pixel);
            return graphics.MeasureString(text, font);
        }
    }
}