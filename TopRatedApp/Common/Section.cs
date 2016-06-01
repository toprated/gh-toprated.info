using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class Section
    {
        public Section(string text, SectionType sectionType, ISectionStyle style)
        {
            Text = text;
            SectionType = sectionType;
            SectionStyle = style;
            W = 0;
            H = 0;
            X = 0;
            Y = 0;
            Path = "";
        }

        public string Text { get; }
        public SectionType SectionType { get; }
        public ISectionStyle SectionStyle { get; }
        public double W { get; set; }
        public double H { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Path { get; set; }
    }
}