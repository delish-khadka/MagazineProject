using Microsoft.AspNetCore.Mvc;

namespace MagazineProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
