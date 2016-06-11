using TopRatedApp.Common.BadgeClasses.Badges;

namespace TopRatedApp.Models
{
    public class TopRatedBadgeViewModel
    {
        public TopRatedBadgeViewModel(TopRatedBadge badge)
        {
            Badge = badge;
        }

        public TopRatedBadge Badge { get; }
    }
}