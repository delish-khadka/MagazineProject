using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazineProject.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="News title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage ="News content is required")]
        public string Description { get; set; }


        public string? Image { get; set; }



        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
