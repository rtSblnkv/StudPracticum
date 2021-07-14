using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Models
{
    public class UserViewModel : User
    {
        [Display(Name = "Подтвердите пароль*")]
        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        [Compare(nameof(Password),ErrorMessage = "Пароли не совпадают. Попробуйте ещё раз.")]
        public string ConfirmPassword { get; set; }
    }
}
