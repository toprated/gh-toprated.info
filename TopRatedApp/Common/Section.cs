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
        }

        public string Text { get; }
        public SectionType SectionType { get; }
        public ISectionStyle SectionStyle { get; }
    }
}