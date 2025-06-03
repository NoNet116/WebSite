using System.ComponentModel.DataAnnotations;
using WebSite.Validators;

namespace WebSite.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина от 2 до 50 символов")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЁё-]{2,50}$", ErrorMessage = "Допускаются только латинские, русские буквы и дефис")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина от 2 до 50 символов")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЁё-]{2,50}$", ErrorMessage = "Допускаются только латинские, русские буквы и дефис")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Длина от 2 до 50 символов")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЁё-]{2,50}$", ErrorMessage = "Допускаются только латинские, русские буквы и дефис")]
        public string? FatherName { get; set; }

        [Required(ErrorMessage = "Укажите электронную почту")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        public string EmailReg { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения")]
        [BirthDateValidation(ErrorMessage = "Дата рождения должна быть корректной")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        [StringLength(15, ErrorMessage = "Логин должен содержать от {2} до {1} символов.", MinimumLength = 2)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(50, ErrorMessage = "Пароль должен содержать от {2} до {1} символов.", MinimumLength = 8)]
        public string PasswordReg { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("PasswordReg", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        
    }
}
