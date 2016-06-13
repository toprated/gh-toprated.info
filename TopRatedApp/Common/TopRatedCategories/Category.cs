using System.Globalization;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.TopRatedCategories
{
    public class Category : ICategory
    {
        public string PercentageString => Percentage.ToString("G", CultureInfo.InvariantCulture);
        public double Percentage { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Count { get; set; }

        public Category(double percentage, int count, int starsFrom, int starsTo = 0)
        {
            Percentage = percentage;
            From = starsFrom;
            To = starsTo;
            Count = count;
        }
    }
}