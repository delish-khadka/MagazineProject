using MagazineProject.Data;
using MagazineProject.Models;
using MagazineProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
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
            var currentTime = DateTime.Now;
            var endTime = currentTime.AddHours(-24);

            var advertisementVM = new MainPageViewModel
            {
                allAdvertisement = _context.Advertisement.Where(a => a.AdvertisementPostedDate >= endTime && a.AdvertisementPostedDate <= currentTime).ToList(),
                allNews = _context.News.Take(1).OrderByDescending(c => c.Date).ToList(),
                allArticles = _context.Article.Take(6).ToList(),
                allJournals = _context.Journal.Take(3).ToList()
            };

            return View(advertisementVM);
            /*var currentTime = DateTime.Now;
            var endTime = currentTime.AddHours(24); // Subtract 24 hours from the current time

            var advertisementVM = new MainPageViewModel
            {
                allAdvertisement = _context.Advertisement.Where(a => a.AdvertisementPostedDate >= endTime).ToList(),
                allNews = _context.News.Take(2).OrderByDescending(c => c.Date).ToList(),
                allArticles = _context.Article.ToList(),
                allJournals = _context.Journal.Take(3).ToList()
            };

            return View(advertisementVM);*/
            /*var settings = _context.Advertisement.All(x=> x.AdvertisementPostedDate <);
            var currentDate = settings.AdvertisementPostedDate;
            var endTime = currentDate.AddHours(24);*/
            /*if(currentDate < endTime)
            {
                var advertisementVM = new MainPageViewModel
                {
                    allAdvertisement = _context.Advertisement.ToList(),
                    allNews = _context.News.Take(2).OrderByDescending(c => c.Date).ToList(),
                    allArticles = _context.Article.ToList(),
                    allJournals = _context.Journal.Take(3).ToList()
                };
                return View(advertisementVM);
            }
            else
            {
                var noAdvertisement = new MainPageViewModel
                {
                    
                    allNews = _context.News.Take(2).OrderByDescending(c => c.Date).ToList(),
                    allArticles = _context.Article.ToList(),
                    allJournals = _context.Journal.Take(3).ToList()
                };
                return View(noAdvertisement);
            }*/


            /*var settings = _context.Advertisement.FirstOrDefault();
            var currentDate = settings.AdvertisementPostedDate;
            var endTime = currentDate.AddHours(24);
            if(currentDate < endTime)
            {
                
            }
            return View*/
        }

        public IActionResult Article(int id)
        {
            var singleArticle = _context.Article.Find(id);
            return View(singleArticle);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}