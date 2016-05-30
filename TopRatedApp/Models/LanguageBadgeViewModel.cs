using System;
using System.Drawing;

namespace TopRatedApp.Models
{
    public class LanguageBadgeViewModel
    {
        public LanguageBadgeViewModel(string lang)
        {
            Language = lang;
        }
        
        public string Language { get; }

        public int GetTextWidth(string text, int fontSize)
        {
            var bitmap = new Bitmap(1, 1);
            var graphics = Graphics.FromImage(bitmap);
            var font = new Font(FontFamily.GenericSansSerif, fontSize);
            var dimension = graphics.MeasureString(text, font);
            return (int)Math.Ceiling(dimension.Width);
        }
    }
}