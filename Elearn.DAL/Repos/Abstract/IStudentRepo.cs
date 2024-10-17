using Elearn.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elearn.DAL.Repos.Abstract
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
        void Delete(string id);
        Student GetById(string id);
    }
}
