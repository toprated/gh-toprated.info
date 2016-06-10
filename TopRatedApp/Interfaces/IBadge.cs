using TopRatedApp.Common;

namespace TopRatedApp.Interfaces
{
    public interface IBadge
    {
        void GenerateSections(ILanguage language, BadgeQueryData bqd);
    }
}