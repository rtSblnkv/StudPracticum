using System.ComponentModel.DataAnnotations;

namespace SurfingBlogRt.Models
{
    public class UserViewModel : User
    {
        [Display(Name = "Подтвердите пароль*")]
        [Required(ErrorMessage = "* Поле обязательно для заполнения")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Войти как компания")]
        public bool LoginAsACompany { get; set; }
    }
}
