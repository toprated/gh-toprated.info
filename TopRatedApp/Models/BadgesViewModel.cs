namespace TopRatedApp.Models
{
    public class BadgesViewModel
    {
        public string UserName { get; private set; }

        public BadgesViewModel(string userName)
        {
            UserName = userName;
        }
    }
}