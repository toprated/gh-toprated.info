using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TopRatedApp.Common;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Helpers
{
    public class GithubApiHelper
    {
        private static async Task<string> LoadJsonString(string url)
        {
            var json = "";
            using (var wc = new WebClient())
            {
                try
                {
                    wc.Headers.Add("User-Agent: Other");
                    Debug.WriteLine($"GETTING: {url}");
                    var r = await wc.DownloadStringTaskAsync(url);

                    json = r;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"{ex.Message} in {ex.StackTrace}");
                    Debug.WriteLine($"Inner: {ex.InnerException?.Message} in {ex.InnerException?.StackTrace}");
                }
            }
            return json.Equals("") ? "" : json;
        }

        private static async Task<JObject> GetJObject(string url)
        {
            var json = await LoadJsonString(url);
            return JObject.Parse(json);
        }

        public static async Task<string> GetLanguageName(string user, string repo)
        {
            var url = $"https://api.github.com/repos/{user}/{repo}";

            var jObj = await GetJObject(url);

            return jObj["language"].Value<string>();
        }

        public static async Task<IRepoData> GetRepoData(string user, string repo)
        {
            var url = $"https://api.github.com/repos/{user}/{repo}";

            var jObj = await GetJObject(url);

            var lang = Languages.GetLangByName(jObj["language"].Value<string>());
            var stars = jObj["stargazers_count"].Value<int>();
            var id = jObj["stargazers_count"].Value<string>();
            var repoData = new RepoData(id, lang, stars);

            return repoData;
        }
    }
}