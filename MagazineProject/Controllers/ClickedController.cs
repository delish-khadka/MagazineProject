using MagazineProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace MagazineProject.Controllers
{
    public class ClickedController : Controller
    {
        private readonly MagazineDbContext _context;

        public ClickedController(MagazineDbContext context)
        {
            _context = context;
        }
        public IActionResult ClickedNews(int id)
        {
            var news = _context.News.FirstOrDefault(x=> x.Id == id);
            return View(news);
        }

        public IActionResult ClickedArticle(int id)
        {
            var article = _context.Article.FirstOrDefault(x => x.Id == id);
            return View(article);
        }
    }
}
