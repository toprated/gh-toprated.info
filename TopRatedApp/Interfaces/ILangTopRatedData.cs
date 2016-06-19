using System.Collections.Generic;
using TopRatedApp.Common.TopRatedCategories;

namespace TopRatedApp.Interfaces
{
    public interface ILangTopRatedData
    {
        List<ICategory> Categories { get; set; }
        int TotalRepos { get; set; }
        ILanguage Language { get; set; }
    }
}