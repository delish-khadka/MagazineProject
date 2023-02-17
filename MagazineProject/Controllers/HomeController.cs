using MagazineProject.Data;
using MagazineProject.Models;
using MagazineProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MagazineProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MagazineDbContext _context;

        public HomeController(ILogger<HomeController> logger, MagazineDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new MainPageViewModel
            {
                allAdvertisement = _context.Advertisement.ToList(),
                allNews = _context.News.Take(2).ToList(),
                allArticles = _context.Article.ToList(),
                allJournals = _context.Journal.ToList(),
            };
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public ActionResult MainViewModel()
        {
            
        }*/
    }
}