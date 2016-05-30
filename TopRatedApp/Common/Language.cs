using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class Language : ILanguage
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public SectionType SectionType { get; set; }

        public Language(string name, string color, string textColor, SectionType sectionType)
        {
            Name = name;
            Color = color;
            TextColor = textColor;
            SectionType = sectionType;
        }
    }
}