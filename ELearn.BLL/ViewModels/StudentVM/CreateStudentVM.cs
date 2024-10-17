using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELearn.BLL.ViewModels.StudentVM
{
    public class CreateStudentVM
    {
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
