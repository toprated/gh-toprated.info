using TopRatedApp.Enums;

namespace TopRatedApp.Interfaces
{
    public interface ILanguage
    {
        string Name { get; set; }
        string Color { get; set; }
        string TextColor { get; set; }
        SectionType SectionType { get; set; }
    }
}