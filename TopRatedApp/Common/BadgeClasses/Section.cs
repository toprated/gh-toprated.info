using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class Section : ISection
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
            Tw = 0;
            Th = 0;
            Path = "";
        }

        public Section(SectionType sectionType, ISectionStyle style, double w, double h)
        {
            Text = "";
            SectionType = sectionType;
            SectionStyle = style;
            W = w;
            H = h;
            X = 0;
            Y = 0;
            Tw = 0;
            Th = 0;
            Path = "";
        }

        public string Text { get; }
        public SectionType SectionType { get; }
        public ISectionStyle SectionStyle { get; }
        public double W { get; set; }
        public double H { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Tw { get; set; }
        public double Th { get; set; }
        public string Path { get; set; }
    }
}