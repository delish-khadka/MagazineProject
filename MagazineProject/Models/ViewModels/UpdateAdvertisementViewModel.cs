using System.ComponentModel.DataAnnotations;

namespace MagazineProject.Models.ViewModels
{
    public class UpdateAdvertisementViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter advertiser name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter content of advertisement")]
        public string Description { get; set; }

        public string? Image { get; set; }
    }
}
