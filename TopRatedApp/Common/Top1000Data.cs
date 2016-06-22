using Newtonsoft.Json;

namespace TopRatedApp.Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Top1000Data
    {
        [JsonProperty(PropertyName = "language-name")]
        public string LangName { get; set; }

        [JsonProperty(PropertyName = "request-date")]
        public string RequestDate { get; set; }

        [JsonProperty(PropertyName = "repos")]
        public RepoData[] Repos { get; set; }

    }
}