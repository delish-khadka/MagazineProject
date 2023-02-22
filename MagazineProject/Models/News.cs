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

        public string TimeAgo
        {
            get
            {
                TimeSpan timeSincePosted = DateTime.Now - Date;

                if (timeSincePosted.TotalMinutes < 1)
                {
                    return "just now";
                }
                else if (timeSincePosted.TotalHours < 1)
                {
                    int minutes = (int)Math.Floor(timeSincePosted.TotalMinutes);
                    return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";
                }
                else if (timeSincePosted.TotalDays < 1)
                {
                    int hours = (int)Math.Floor(timeSincePosted.TotalHours);
                    return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
                }
                else
                {
                    int days = (int)Math.Floor(timeSincePosted.TotalDays);
                    return $"{days} day{(days > 1 ? "s" : "")} ago";
                }
            }
        }
    }
}
