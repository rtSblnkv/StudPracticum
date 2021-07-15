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
        [RegularExpression(@"[a-zA-Zа-яА-Я0-9_]{6,20}", ErrorMessage = "Псевдоним может содержать от 3 до 20 символов. Латиница, кириллица, цифры и подчёркивания")]
        [Display(Name = "Псевдоним*")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Некорректный формат электронной почты")]
        [Display(Name = "Почта*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6 символов")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20 символов")]
        [RegularExpression(@"[a-zA-Zа-яА-Я0-9_]{6,20}", ErrorMessage = "Пароль может содержать от 6 до 20 символов. Латиница, кириллица, цифры и подчёркивания")]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }

        [MaxLength(100, ErrorMessage = "Превышение лимита по символам (100)")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "Превышение лимита по символам (100)")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

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
