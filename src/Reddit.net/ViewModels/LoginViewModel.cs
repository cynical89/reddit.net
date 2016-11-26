using System.ComponentModel.DataAnnotations;

namespace Reddit.net.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
