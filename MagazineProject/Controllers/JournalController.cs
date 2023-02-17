using MagazineProject.Data;
using MagazineProject.Models;
using MagazineProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MagazineProject.Controllers
{
    public class JournalController : Controller
    {
        private readonly MagazineDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public JournalController(MagazineDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var journal = await _context.Journal.ToListAsync();
            return View(journal);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Journal == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.FirstOrDefaultAsync(x => x.Id == id);
            if(journal == null)
            {
                return NotFound();
            }
            return View(journal);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JournalViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Journal journal = new Journal
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = model.Author,
                    Image = uniqueFileName
                };
                _context.Add(journal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Journal == null)
            {
                return NotFound();
            }

            var journal = await _context.Journal.FirstOrDefaultAsync(x=>x.Id == id);
            if(journal == null)
            {
                return NotFound();
            }
            JournalViewModel JVM = new JournalViewModel()
            {
                Title = journal.Title,
                Description = journal.Description,
                Author = journal.Author,
                JournalImage = null
            };
            return View(JVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JournalViewModel model)
        {
            string uniqueFileName = UploadedFile(model);
            var journal = await _context.Journal.FindAsync(id);
            if(journal != null)
            {
                journal.Title = model.Title;
                journal.Description = model.Description;
                journal.Author = model.Author;
                journal.Image = uniqueFileName;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Journal== null)
            {
                return NotFound();  
            }
            var journal = await _context.Journal.FirstOrDefaultAsync(x=> x.Id == id);
            if(journal == null)
            {
                return NotFound(); 
            }
            return View(journal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if(_context.Journal == null)
            {
                return NotFound();
            }
            var journal = await _context.Journal.FirstOrDefaultAsync(x => id == x.Id);
            if(journal == null)
            {
                return NotFound();
            }
            else
            {
                _context.Journal.Remove(journal);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public string UploadedFile(JournalViewModel model)
        {
            string uniqueFileName = null;
            if (model.JournalImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.JournalImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.JournalImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
