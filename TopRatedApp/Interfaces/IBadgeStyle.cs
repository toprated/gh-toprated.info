namespace TopRatedApp.Interfaces
{
    public interface IBadgeStyle
    {
        ISectionStyle CommonTextStyle { get; set; }
        int PaddingBorders { get; set; }
        int PaddingMiddle { get; set; }
        int PaddingTop { get; set; }
        int PaddingBottom { get; set; }
        int Radius { get; set; }
    }
}