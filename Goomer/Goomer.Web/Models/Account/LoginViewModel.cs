using System.ComponentModel.DataAnnotations;

namespace Goomer.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Е-майл")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

}