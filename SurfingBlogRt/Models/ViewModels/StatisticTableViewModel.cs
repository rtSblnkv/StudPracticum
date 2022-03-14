using System.ComponentModel.DataAnnotations;

namespace SurfingBlogRt.Models
{
    public class StatisticTableViewModel
    {
        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Тематика")]
        public string Theme { get; set; }

        [Display(Name = "Тип")]
        public string Type { get; set; }
    }
}
