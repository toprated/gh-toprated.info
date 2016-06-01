namespace TopRatedApp.Interfaces
{
    public interface IFontStyle
    {
        string FontFamily { get; set; }
        int FontSize { get; set; }
        string FontColor { get; set; }
        string FontShadowColor { get; set; }

        double GetTextWidth(string text);
        double GetTextHeight(string text);
    }
}