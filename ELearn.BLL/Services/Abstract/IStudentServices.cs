using ELearn.BLL.ViewModels.StudentVM;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.BLL.Services.Abstract
{
    public interface IStudentServices
    {
        IEnumerable<GetStudentVM> GetAll();
        GetStudentVM GetById(string id);
        CreateStudentVM Add(CreateStudentVM studentVM);
        void Delete(string id);
        void Update(string id,EditStudentVm studentVM);
        
    }
}
