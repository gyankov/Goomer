using System.ComponentModel.DataAnnotations;

namespace Goomer.Web.Models.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}