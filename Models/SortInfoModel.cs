using System.ComponentModel.DataAnnotations;

namespace TestTask1.Models
{
    public class SortInfoModel
    {
        [Required]
        public string SortType { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
