using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class BadgeGeometry : IBadgeGeometry
    {
        public IBadgePadding Padding { get; set; }
        public int Radius { get; set; }

        public BadgeGeometry(IBadgePadding padding, int radius)
        {
            Padding = padding;
            Radius = radius;
        }
    }
}