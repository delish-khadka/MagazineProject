using MagazineProject.Data;
using MagazineProject.Models;
using MagazineProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazineProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly MagazineDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public NewsController(MagazineDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _context.News.ToListAsync();
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || _context.News== null)
            {
                return NotFound();
            }
            var news = _context.News.FirstOrDefault(x => x.Id == id) ;
            if(news == null)
            {
                return NotFound();
            }
            return View(news);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }
            var news = _context.News.FirstOrDefault(x => x.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            if(_context.News == null)
            {
                return NotFound();
            }
            var news = _context.News.Find(id);
            if(news != null)
            {
                _context.News.Remove(news);
            }
            _context.SaveChanges();
            return (RedirectToAction(nameof(Index)));
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);


                News news = new News
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = uniqueFileName,
                    Date = DateTime.Now
                };
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(x => x.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            NewsViewModel NVM = new NewsViewModel()
            {
                Title = news.Title,
                Description = news.Description,
                Date = news.Date,
                NewsImage = null
            };
            return View(NVM);
        }

        [HttpPost]  
        public async Task<IActionResult> Edit(int id, NewsViewModel model)
        {
            string uniqueFileName = UploadedFile(model);
            var news = await _context.News.FindAsync(id);
            if (news != null) {
                news.Title = model.Title;
                news.Description = model.Description;
                news.Date = model.Date;
                news.Image = uniqueFileName;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(NewsViewModel model)
        {
            string uniqueFileName = null;

            if (model.NewsImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.NewsImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.NewsImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
