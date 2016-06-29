using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class Language : ILanguage
    {
        public string Name { get; set; }
        public Octokit.Language OctokitLanguage { get; set; }
        public string ApiName { get; set; }
        public string EncodedName { get; set; }
        public string Color { get; set; }
        public string TextColor { get; set; }
        public string TextShadowColor { get; set; }
        public SectionType SectionType { get; set; }

        public Language(string name, string apiName, string encodedName, string color, string textColor, 
            string textShadowColor, SectionType sectionType, Octokit.Language octoLang)
        {
            Name = name;
            ApiName = apiName;
            EncodedName = encodedName;
            Color = color;
            TextColor = textColor;
            TextShadowColor = textShadowColor;
            SectionType = sectionType;
            OctokitLanguage = octoLang;
        }
    }
}