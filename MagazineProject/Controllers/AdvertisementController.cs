using MagazineProject.Data;
using MagazineProject.Models.ViewModels;
using MagazineProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazineProject.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly MagazineDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdvertisementController(MagazineDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _context.Advertisement.ToListAsync();
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertisementViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);


                Advertisement advertisement = new Advertisement
                {

                    Title = model.Title,
                    Description = model.Description,
                    Image = uniqueFileName,
                    AdvertisementPostedDate = model.AdvertisementPostedDate
                };
                _context.Add(advertisement);
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

            var advertisement = await _context.Advertisement.FirstOrDefaultAsync(x => x.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            AdvertisementViewModel AVM=new AdvertisementViewModel()
            {
                Title = advertisement.Title,
                Description = advertisement.Description,
                AdvertisementImage = null,
                AdvertisementPostedDate = advertisement.AdvertisementPostedDate
            };
            return View(AVM);
            /*var advertisement = await _context.Advertisement.FirstOrDefaultAsync(x => x.ID == id);
            if (advertisement != null)
            {
                var viewModel = new AdvertisementViewModel()
                {
                    Title = advertisement.Title,
                    Description = advertisement.Description,
                    AdvertisementImage = advertisement.Image,
                };
                return View(viewModel);
                *//*return (View);*//*
            }
            return RedirectToAction("Index");*/
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdvertisementViewModel model)
        {
            string uniqueFileName = UploadedFile(model);
            var advertisement = await _context.Advertisement.FindAsync(id);
            if (advertisement != null) {
                
                advertisement.Title = model.Title;
                advertisement.Description = model.Description;
                advertisement.Image = uniqueFileName;
                advertisement.AdvertisementPostedDate = model.AdvertisementPostedDate;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);


                Advertisement advertisement = new Advertisement
                {

                    Title = model.Title,
                    Description = model.Description,
                    Image = uniqueFileName,
                };
                _context.Update(advertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisement.FirstOrDefaultAsync(x => x.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisement.FirstOrDefaultAsync(x => x.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Advertisement == null)
            {
                return NotFound();
            }
            var article = await _context.Advertisement.FindAsync(id);
            if (article != null)
            {
                _context.Advertisement.Remove(article);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private string UploadedFile(AdvertisementViewModel model)
        {
            string uniqueFileName = null;

            if (model.AdvertisementImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.AdvertisementImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.AdvertisementImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        /*private string UpdateUploadedFile(UpdateAdvertisementViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }*/
    }
}
