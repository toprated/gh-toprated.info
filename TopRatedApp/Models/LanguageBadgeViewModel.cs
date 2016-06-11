using TopRatedApp.Common.BadgeClasses.Badges;

namespace TopRatedApp.Models
{
    public class LanguageBadgeViewModel
    {
        public LanguageBadgeViewModel(LanguageBadge badge)
        {
            Badge = badge;
        }
        
        public LanguageBadge Badge { get; }

    }
}