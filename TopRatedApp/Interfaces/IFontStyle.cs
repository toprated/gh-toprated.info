using System.Drawing;

namespace TopRatedApp.Interfaces
{
    public interface IFontStyle
    {
        string FontFamily { get; set; }
        int FontSize { get; set; }
        string FontColor { get; set; }
        string FontShadowColor { get; set; }

        SizeF GetTextSize(string text);
    }
}