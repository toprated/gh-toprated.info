namespace TopRatedApp.Interfaces
{
    public interface IBadgeStyle
    {
        IFontStyle DefaultFontStyle { get; set; }
        ISectionStyle DefaultTextSectionStyle { get; set; }
        IBadgeGeometry BadgeGeometry { get; set; }
        double ShadowRight { get; set; }
        double ShadowBottom { get; set; }
    }
}