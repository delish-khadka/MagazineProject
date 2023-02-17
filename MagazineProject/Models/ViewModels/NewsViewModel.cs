using System.ComponentModel.DataAnnotations;

namespace MagazineProject.Models.ViewModels
{
    public class NewsViewModel

    {
        [Required(ErrorMessage = "News title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "News content is required")]
        public string Description { get; set; }


        public IFormFile? NewsImage { get; set; }



        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
