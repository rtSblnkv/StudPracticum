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
        public string ConfirmPassword { get; set; }
    }
}
