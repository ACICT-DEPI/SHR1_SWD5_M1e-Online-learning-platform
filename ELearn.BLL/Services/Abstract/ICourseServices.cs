
using ELearn.BLL.ViewModels.CourseVM;
using ELearn.BLL.ViewModels.StudentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.BLL.Services.Abstract
{
    public interface ICourseServices
    {
        IEnumerable<GetCourseVm> GetAll();
        GetCourseVm GetById(int id);
        CreateCourseVm Add(CreateCourseVm courseVM);
        void Delete(int id);
        void Update(int id,EditCourseVm courseVm);
       
    }
}
