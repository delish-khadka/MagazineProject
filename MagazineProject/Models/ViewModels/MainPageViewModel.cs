namespace MagazineProject.Models.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<Advertisement> allAdvertisement { get; set; }
        public IEnumerable<Article> allArticles { get; set; }
        public IEnumerable<Journal> allJournals { get; set; }
        public IEnumerable<News> allNews { get; set; }
    }
}
