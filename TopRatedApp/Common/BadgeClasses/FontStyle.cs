using System.Drawing;
using System.Windows.Forms;
using TopRatedApp.Helpers;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class FontStyle : IFontStyle
    {
        private const string DefaultFontFamily = "DejaVu Sans,Verdana,Geneva,sans-serif";
        private const string DefaultFontWeight = "normal";
        private const int DefaultFontSize = 11;
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
            FontSize = DefaultFontSize;
            FontColor = ColorHelper.GetFontColor(badgeTheme);
            FontShadowColor = ColorHelper.GetFontShadowColor(badgeTheme);
            FontWeight = "normal";
        }
        
        public FontStyle(string badgeTheme, int fontSize = 0, string fontWeight = "", string fontFamily = "")
        {
            FontFamily = fontFamily.Equals("") ? DefaultFontFamily : fontFamily;
            FontSize = fontSize.Equals(0) ? DefaultFontSize : fontSize;
            FontColor = ColorHelper.GetFontColor(badgeTheme);
            FontShadowColor = ColorHelper.GetFontShadowColor(badgeTheme);
            FontWeight = fontWeight.Equals("") ? DefaultFontWeight : fontWeight;
        }

        public SizeF GetTextSize(string text)
        {
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font(FontFamily, FontSize);
            var fontP = new Font(FontFamily, FontSize, GraphicsUnit.Pixel);
            var sW = graphics.MeasureString(text, font, 0, StringFormat.GenericTypographic);
            var sH = graphics.MeasureString(text, fontP, 0, StringFormat.GenericTypographic);
            return new SizeF(sW.Width, sH.Height);
        }
    }
}