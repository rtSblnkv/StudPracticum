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

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MinLength(3, ErrorMessage = "Минимальная длина пароля - 3 символа")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20 символов")]
        [Display(Name = "Псевдоним*")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Display(Name = "Почта*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20 символов")]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }

        [MaxLength(100, ErrorMessage = "Превышение лимита по символам (100)")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "Превышение лимита по символам (100)")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Выберите фото")]
        public Guid? Photo { get; set; }

        [Display(Name = "Контактная информация")]
        [MaxLength(500, ErrorMessage = "Превышение лимита по символам (500)")]
        public string Contacts { get; set; }

        [MaxLength(500, ErrorMessage = "Превышение лимита по символам (500)")]
        [Display(Name = "О себе")]
        public string AboutMe { get; set; }

        [MaxLength(500, ErrorMessage = "Превышение лимита по символам (500)")]
        [Display(Name = "Достижения")]
        public string Achievements { get; set; }
    }

}
