using TopRatedApp.Common.Badges;

namespace TopRatedApp.Models
{
    public class SimpleLanguageBadgeViewModel
    {
        public SimpleLanguageBadgeViewModel(LanguageBadge badge)
        {
            Badge = badge;
        }
        
        public LanguageBadge Badge { get; }

    }
}