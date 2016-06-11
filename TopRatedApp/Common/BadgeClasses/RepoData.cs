using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public class RepoData : IRepoData
    {
        public int Stars { get; set; }
        public ILanguage Lang { get; set; }
        public string Id { get; set; }

        public RepoData(string id, ILanguage lang, int stars)
        {
            Id = id;
            Lang = lang;
            Stars = stars;
        }
    }
}