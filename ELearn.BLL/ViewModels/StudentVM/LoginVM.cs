using System.ComponentModel.DataAnnotations;

namespace ELearn.BLL.ViewModels.StudentVM
{
    public class LoginVM
    {
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe {  get; set; }
    }
}
