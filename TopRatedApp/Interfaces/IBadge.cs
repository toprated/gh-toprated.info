using TopRatedApp.Common.BadgeClasses;

namespace TopRatedApp.Interfaces
{
    public interface IBadge
    {
        void GenerateSections(ILanguage language, BadgeQueryData bqd);
    }
}