using System.ComponentModel.DataAnnotations;

namespace MagazineProject.Models.ViewModels
{
    public class JournalViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body content is required")]
        public string Description { get; set; }
        
        public string? Author { get; set; }

        public IFormFile JournalImage { get; set; }
    }
}
