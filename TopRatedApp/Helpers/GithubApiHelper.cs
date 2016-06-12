using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TopRatedApp.Common;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Common.TopRatedCategories;
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

        public static string GetLangApiUrl(string lang, int page, int perPage)
        {
            return
                $"https://api.github.com/search/repositories?q=+language:{lang}&sort=stars" +
                $"&order=desc&page={page}&per_page={perPage}";

        }

        //public static async Task<string> GetTopPercent(IRepoData repoData)
        //{
        //}

        public static async Task<List<ICategory>> GetTopCategories(string langApiName)
        {
            var r = new List<ICategory>();
            var jObj = await GetJObject(GetLangApiUrl(langApiName, 1, 1));
            var total = jObj["total_count"].Value<int>();

            foreach (var d in Categories.CategoriesArray)
            {
                var categoryTotalCount = (int)(total * d / 100);
                var pageNumber = categoryTotalCount / 100;
                var pagePosition = categoryTotalCount % 100;
                var reposJObj = await GetJObject(GetLangApiUrl(langApiName, pageNumber, pagePosition));
                var jRepos = reposJObj["items"].Children().ToList().Select(jT => JObject.Parse(jT.ToString()));
                var j = 0;

                foreach (var jRepo in jRepos)
                {
                    j++;
                    if (j!=pagePosition) continue;
                    r.Add(new Category(d, int.Parse(jRepo.GetValue("stargazers_count").ToString())));
                }
            }

            return r;

        }
    }
}