namespace TopRatedApp.Interfaces
{
    public interface ICategory
    {
        string PercentageString { get; }
        double Percentage { get; set; }
        int From { get; set; }
        int To { get; set; }
    }
}