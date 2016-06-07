namespace TopRatedApp.Interfaces
{
    public interface IRepoData
    {
        int Stars { get; set; }
        ILanguage Lang { get; set; }
        string Id { get; set; }
    }
}