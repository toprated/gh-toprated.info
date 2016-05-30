using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class SectionStyle : ISectionStyle
    {
        public IFontStyle FontStyle { get; set; }
        public string BackgroundColor { get; set; }
    }
}