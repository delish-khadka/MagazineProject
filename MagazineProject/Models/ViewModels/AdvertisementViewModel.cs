using System.ComponentModel.DataAnnotations;

namespace MagazineProject.Models.ViewModels
{
    public class AdvertisementViewModel
    {
        [Required(ErrorMessage = "Enter advertiser name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter content of advertisement")]
        public string Description { get; set; }

        public IFormFile? AdvertisementImage { get; set; }
    }
}
