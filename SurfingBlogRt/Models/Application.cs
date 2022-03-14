using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfingBlogRt.Models
{
    [Table("Application ")]
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int AnnouncementId { get; set; }

        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }

        [Required]
        [Display(Name = "Контактные данные")]
        public string Contacts { get; set; }

        [MaxLength(5000, ErrorMessage = "Максимальная длина 5000 символов")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
