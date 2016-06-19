using System.Collections.Generic;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.TopRatedCategories
{
    public class LangTopRatedData : ILangTopRatedData
    {
        public List<ICategory> Categories { get; set; }
        public int TotalRepos { get; set; }
        public ILanguage Language { get; set; }

        public LangTopRatedData()
        {
            Categories = new List<ICategory>();
        }
    }
}