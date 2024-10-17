using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.BLL.ViewModels.StudentVM
{
    public class EditStudentVm
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
