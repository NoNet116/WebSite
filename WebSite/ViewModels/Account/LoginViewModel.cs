using System.ComponentModel.DataAnnotations;

namespace WebSite.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите email.")]
        [Display(Name = "Email")]
        public  string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }
}
