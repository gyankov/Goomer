using System.ComponentModel.DataAnnotations;

namespace Goomer.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Моля въведете е-майл.")]
        [EmailAddress(ErrorMessage = "Е-мейлът не е валиден.")]
        [Display(Name = "Е-майл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля въведете парола.")]
        [StringLength(100, ErrorMessage = "Паролата трябва да бъде между 6 и 100 символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Двете пароли не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}