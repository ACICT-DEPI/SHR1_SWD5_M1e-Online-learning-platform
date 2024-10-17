using Elearn.DAL.Context;
using Elearn.DAL.Models;
using Elearn.DAL.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elearn.DAL.Repos.Implementation
{
    public class CourseRepo:GenericRepo<Course>,ICourseRepo
    {
        private readonly ElearnContext _context;

        public CourseRepo(ElearnContext context):base(context)
        {
            _context = context;
        }
    }
}
