using TopRatedApp.Enums;

namespace TopRatedApp.Interfaces
{
    public interface ISection
    {
        string Text { get; }
        SectionType SectionType { get; }
        ISectionStyle SectionStyle { get; }
        double W { get; set; }
        double H { get; set; }
        double X { get; set; }
        double Y { get; set; }
        string Path { get; set; }
    }
}