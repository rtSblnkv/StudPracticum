using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Display(Name = "Псевдоним*")]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Почта*")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }

        [MaxLength(100)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Выберите фото")]
        public Guid Photo { get; set; }

        [Display(Name = "Контактная информация")]
        [MaxLength(500)]
        public string Contacts { get; set; }

        [MaxLength(500)]
        [Display(Name = "О себе")]
        public string AboutMe { get; set; }

        [MaxLength(500)]
        [Display(Name = "Достижения")]
        public string Achievements { get; set; }
    }

}
