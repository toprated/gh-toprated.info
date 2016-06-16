using System;
using System.Diagnostics;
using System.IO;
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
    public class GitHubHelper
    {
        private static string ClientDataPath => Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),
            "clientData.json");

        private static JObject JClientData
            =>
                JObject.Parse(
                    File.ReadAllText(ClientDataPath));

        internal static string SetClientData(string id, string secret)
        {
            var result = "Done:)";
            try
            {
                var data = $"{{\r\n  \"clientId\": \"{id}\",\r\n  \"clientSecret\": \"{secret}\"\r\n}}";
                if (ClientId.Equals("") && ClientSecret.Equals(""))
                {
                    File.WriteAllText(ClientDataPath, data);
                }
                else
                {
                    result = "Data is not empty!";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}! {ex.StackTrace}";
            }
            return result;
        }

        public static string ClientId = JClientData["clientId"].Value<string>();
        public static string ClientSecret = JClientData["clientSecret"].Value<string>();
        
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
            try
            {
                var url = $"https://api.github.com/repos/{user}/{repo}";

                var jObj = await GetJObject(url);

                var lang = Languages.GetLangByName(jObj["language"].Value<string>());
                var stars = jObj["stargazers_count"].Value<int>();
                var id = jObj["stargazers_count"].Value<string>();
                var repoData = new RepoData(id, lang, stars);

                return repoData;
            }
            catch (Exception)
            {
                return new RepoData("0", Languages.UnknownLanguage, 0);
            }
        }

        public static string GetLangSearchApiUrl(string lang, int page, int perPage, int starsMoreThen = 500000)
        {
            var url =
                "https://api.github.com/search/repositories?" +
                $"q=+language:{lang}+stars:>{starsMoreThen}&sort=stars" +
                $"&order=desc&page={page}&per_page={perPage}";
            //Debug.WriteLine("url: " + url);
            return url;

        }

        //public static async Task<string> GetTopPercent(IRepoData repoData)
        //{
        //}

        public static async Task<ILangTopRatedData> GetTopCategories(ILanguage lang)
        {
            var data = new LangTopRatedData();
            var langApiName = lang.ApiName;
            var jObj = await GetJObject(GetLangSearchApiUrl(langApiName, 1, 1));
            var totalAll = jObj["total_count"].Value<int>();
            data.TotalRepos = totalAll;

            var count = 0;

            //setting categories with % and count
            foreach (var d in Categories.Array)
            {
                var cat =
                    new Category(
                        d,
                        (int) (totalAll*d/100));

                if (cat.Count < 1000)
                {
                    var pageNumber = cat.Count / 100;
                    var pagePosition = cat.Count % 100;
                    var reposJObj = await GetJObject(GetLangSearchApiUrl(langApiName, pageNumber, 100));
                    var jRepos = reposJObj["items"].Children().ToList().Select(jT => JObject.Parse(jT.ToString()));
                    var j = 0;

                    foreach (var jRepo in jRepos)
                    {
                        j++;
                        if (j != pagePosition) continue;
                        var stars = int.Parse(jRepo.GetValue("stargazers_count").ToString());
                        data.Categories.Add(new Category(0, stars));
                    }
                }

                data.Categories.Add(cat);
            }
            
            /*while (count < data.Categories.Count)
            {
                var reposJObj = await GetJObject(GetLangSearchApiUrl(langApiName, 10, 100));
                count++;
            }*/

            return data;

        }
    }
}