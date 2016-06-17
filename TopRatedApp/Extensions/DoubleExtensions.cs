using System.Globalization;

namespace TopRatedApp.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToAttrData(this double s)
        {
            return s.ToString("G", CultureInfo.InvariantCulture);
        }
    }
}