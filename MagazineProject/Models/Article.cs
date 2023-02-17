using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazineProject.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Article title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Article body is required")]
        public string Description { get; set; }

        public string? Genre { get; set; }
    }
}
