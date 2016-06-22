namespace TopRatedApp.Interfaces
{
    public interface IRepoData
    {
        int Stars { get; set; }
        ILanguage Lang { get; set; }
        string Id { get; set; }
        int Place { get; set; }
        string UserName { get; set; }
        string RepoName { get; set; }
    }
}