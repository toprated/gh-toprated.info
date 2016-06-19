using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        internal static async Task<ClientData> GetClientData()
        {
            using (var reader = File.OpenText(ClientDataPath))
            {
                var fileText = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<ClientData>(fileText);
            }
        }
        
        internal static async Task<string> SaveClientDataAsync(ClientData clientData)
        {
            var result = "Done:)";
            try
            {
                var data = JsonConvert.SerializeObject(clientData);
                var current = await GetClientData();
                if (current.ClientId.Equals("") && current.ClientSecret.Equals("")
                    && current.Login.Equals("") && current.Password.Equals(""))
                {
                    using (var file = File.CreateText(ClientDataPath))
                    {
                        await file.WriteAsync(data);
                    }
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
        
        private static async Task<string> LoadJsonString(string url)
        {
            var json = "";
            using (var wc = new WebClient())
            {
                var count = 0;
                bool success;
                do
                {
                    success = false;
                    count++;
                    try
                    {
                        Debug.WriteLine($"try #{count}");
                        var cd = await GetClientData();
                        var credentials = Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(cd.Login + ":" + cd.Password));
                        Debug.WriteLine($"CR: {credentials} " + cd.Login + ":" + cd.Password);
                        wc.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
                        wc.Proxy = null;
                        wc.Headers.Add(HttpRequestHeader.Accept, "application/xml");
                        wc.Headers.Add(HttpRequestHeader.ContentType, "application/xml; charset=utf-8");
                        wc.Headers.Add(HttpRequestHeader.Authorization, "Basic " + credentials);
                        wc.Credentials = new NetworkCredential(cd.Login, cd.Password);

                        //wc.Headers.Add("User-Agent: Other");
                        Debug.WriteLine($"GETTING: {url}");
                        var r = await wc.DownloadStringTaskAsync(url);

                        json = r;
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"{ex.Message} in {ex.StackTrace}");
                        Debug.WriteLine($"Inner: {ex.InnerException?.Message} in {ex.InnerException?.StackTrace}");
                    }
                } while (!success && count <= 5);
                
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