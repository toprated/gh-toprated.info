using TopRatedApp.Common.BadgeClasses.Badges;

namespace TopRatedApp.Models
{
    public class Top1000BadgeViewModel
    {
        public Top1000BadgeViewModel(Top1000Badge badge)
        {
            Badge = badge;
        }

        public Top1000Badge Badge { get; }
    }
}