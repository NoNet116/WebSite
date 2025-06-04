using System.ComponentModel.DataAnnotations;

namespace WebSite.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите email.")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public  string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
