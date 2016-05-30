namespace TopRatedApp.Interfaces
{
    public interface IBadgeStyle
    {
        ISectionStyle CommonTextStyle { get; set; }
        string PaddingBorders { get; set; }
        string PaddingMiddle { get; set; }
        string PaddingTop { get; set; }
        string PaddingBottom { get; set; }
    }
}