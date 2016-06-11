using TopRatedApp.Common;
using TopRatedApp.Common.BadgeClasses;

namespace TopRatedApp.Interfaces
{
    public interface IBadgeBase
    {
        double Width { get; }
        double Height { get; }
        Section[] Sections { get; }
        BadgeQueryData BadgeQueryData { get; }
        IFontStyle DefaultFontStyle { get; }
        ISectionStyle DefaultTextSectionStyle { get; }
        IBadgeStyle BadgeStyle { get; }
        IBadgeGeometry BadgeGeometry { get; }
        void SetSections(Section[] sections);
    }
}