namespace TopRatedApp.Models
{
    public class LanguageBadgeViewModel
    {
        public LanguageBadgeViewModel(string lang)
        {
            Language = lang;
        }
        
        public string Language { get; }
    }
}