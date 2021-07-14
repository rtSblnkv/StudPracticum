using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Models
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Display(Name = "Псевдоним*")]
        public string Nickname { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }


        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

    }
}
