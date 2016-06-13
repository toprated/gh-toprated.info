using System.Collections.Generic;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.TopRatedCategories
{
    public class LangTopRatedData : ILangTopRatedData
    {
        public List<Category> Categories { get; set; }
        public int TotalRepos { get; set; }
        public ILanguage Language { get; set; }

        public LangTopRatedData()
        {
            Categories = new List<Category>();
        }
    }
}