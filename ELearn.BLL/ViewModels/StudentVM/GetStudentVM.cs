using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ELearn.BLL.ViewModels.StudentVM
{
    public class GetStudentVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
