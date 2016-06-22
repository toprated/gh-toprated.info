using Newtonsoft.Json;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RepoData : IRepoData
    {
        [JsonProperty(PropertyName = "stars")]
        public int Stars { get; set; }

        [JsonProperty(PropertyName = "language")]
        public ILanguage Lang { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "place")]
        public int Place { get; set; }

        [JsonProperty(PropertyName = "user-name")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "repo-name")]
        public string RepoName { get; set; }

        public RepoData(string id = "-1", ILanguage lang = null, int stars = 0, 
            int place = 0, string user = "", string repo = "")
        {
            Place = place;
            Id = id;
            Lang = lang ?? Languages.UnknownLanguage;
            Stars = stars;
            UserName = user;
            RepoName = repo;
        }
    }
}