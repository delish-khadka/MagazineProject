using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazineProject.Models
{
    public class Journal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body content is required")]
        public string Description { get; set; }

        public string? Author { get; set; }
        [Required(ErrorMessage ="Journal image is required")]
        public string Image { get; set; }

    }
}
