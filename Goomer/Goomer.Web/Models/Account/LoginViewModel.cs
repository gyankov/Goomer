using System.ComponentModel.DataAnnotations;

namespace Goomer.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Моля въведете е-майл.")]
        [Display(Name = "Е-майл")]
        [EmailAddress(ErrorMessage = "Е-мейлът не е валиден.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля въведете парола.")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

}