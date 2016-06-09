using TopRatedApp.Common;

namespace TopRatedApp.Interfaces
{
    public interface IBadgeBase
    {
        double Width { get; }
        double Height { get; }
        Section[] Sections { get; }
        string Theme { get; }
        IFontStyle DefaultFontStyle { get; }
        ISectionStyle DefaultTextSectionStyle { get; }
        IBadgeStyle BadgeStyle { get; }
        IBadgeGeometry BadgeGeometry { get; }
        void SetSections(Section[] sections);
    }
}