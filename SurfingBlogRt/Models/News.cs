using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfingBlogRt.Models
{
    [Table("News")]
    public class News
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5000)]
        public string Text{ get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public Guid? Image { get; set; }

        public string CreateDateLabel =>
        CreateDate.Date.ToString("dd.MM.yyyy") + " в " + CreateDate.ToString("HH:mm");
    }
}
