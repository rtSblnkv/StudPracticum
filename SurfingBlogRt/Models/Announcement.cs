using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfingBlogRt.Models
{
    [Table("Announcement")]
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual User Company { get; set; }

        [Required]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual AnnoucementType Type { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(5000, ErrorMessage = "Максимальная длина 5000 символов")]
        [Display(Name = "Описание*")]
        public string Description { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(100, ErrorMessage = "Максимальная длина 100 символов")]
        [Display(Name = "Название*")]
        public string Name { get; set; }
         
        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(50, ErrorMessage = "Максимальная длина 50 символов")]
        [Display(Name = "Тематика*")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(200, ErrorMessage = "Максимальная длина 200 символов")]
        [Display(Name = "Локация*")]
        public string Location { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MaxLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        [Display(Name = "Формат*")]
        public string Format { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Display(Name = "Дата начала*")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Range(0, 366, ErrorMessage = "Введите продолжительность больше {1}")]
        [Display(Name = "Продолжительность (дни)*")]
        public int DurationInDays { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        public DateTime CreateDate { get; set; }

        public string CreateDateLabel =>
        CreateDate.Date.ToString("dd.MM.yyyy") + " в " + CreateDate.ToString("HH:mm");

        public string StartDateLabel =>
        StartDate.Date.ToString("dd.MM.yyyy");
    }
}
