using System.Drawing;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class FontStyle : IFontStyle
    {
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public string FontColor { get; set; }
        public string FontShadowColor { get; set; }

        public FontStyle(string fontFamily, int fontSize, string fontColor, string fontShadowColor)
        {
            FontFamily = fontFamily;
            FontSize = fontSize;
            FontColor = fontColor;
            FontShadowColor = fontShadowColor;
        }

        /*var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font(FontFamily.GenericSansSerif, fontSize);
            var dimension = graphics.MeasureString(text, font);
            return (int)Math.Ceiling(dimension.Width);*/

        public SizeF GetTextSize(string text)
        {
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font(FontFamily, FontSize);//, GraphicsUnit.Pixel);
            return graphics.MeasureString(text, font);
        }
    }
}