using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazineProject.Models
{
    public class Advertisement
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Enter advertiser name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter content of advertisement")]
        public string Description { get; set; }

        public string? Image { get; set; }

    }
}
