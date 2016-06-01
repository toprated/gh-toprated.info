using TopRatedApp.Common;

namespace TopRatedApp.Interfaces
{
    public interface IBadgeBase
    {
        double Width { get; }
        double Height { get; }
        Section[] Sections { get; }
        string Theme { get; }
        IFontStyle FontStyle { get; }
        ISectionStyle CommonTextStyle { get; }
        IBadgeStyle Style { get; }
        void SetSections(Section[] sections);
    }
}