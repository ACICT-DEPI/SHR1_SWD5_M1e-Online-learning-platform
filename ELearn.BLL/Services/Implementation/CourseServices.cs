using Elearn.DAL.Models;
using Elearn.DAL.Repos.Abstract;
using Elearn.DAL.Repos.Implementation;
using ELearn.BLL.Services.Abstract;
using ELearn.BLL.ViewModels.CourseVM;
using ELearn.BLL.ViewModels.StudentVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.BLL.Services.Implementation
{
    public class CourseServices:ICourseServices
    {
        private readonly ICourseRepo _courserepo;
        public CourseServices(ICourseRepo courseRepo) 
        {
            _courserepo = courseRepo;
        }

        public CreateCourseVm Add(CreateCourseVm courseVM)
        {
            var courseEntity = new Course
            {
                Title = courseVM.Title,
                Description = courseVM.Description,
            };

            _courserepo.Create(courseEntity);
            _courserepo.SaveChanges();
            return courseVM;
        }

        public void Delete(int id)
        {
            
            _courserepo.Delete(id);
            _courserepo.SaveChanges();
        }

        public IEnumerable<GetCourseVm> GetAll()
        {
            var courseEntities = _courserepo.GetAll();
            var courseVm = courseEntities.Select(course => new GetCourseVm
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,

            });
            return courseVm;
        }

        public GetCourseVm GetById(int id)
        {
            var courseEntities = _courserepo.GetById(id);
            if (courseEntities == null)
            {
                throw new KeyNotFoundException($"Course with id {id} not found.");
            }
            _courserepo.SaveChanges();
            var courseVm = new GetCourseVm
            {
               Id= courseEntities.Id,
               Description= courseEntities.Description,
               Title= courseEntities.Title,
            };

            return courseVm;
        }

        public void Update(int id ,EditCourseVm courseVm)
        {
            var course = _courserepo.GetById(id);
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with id {courseVm.Id} not found.");
            }

            course.Id = courseVm.Id;
            course.Title = courseVm.Title;
            course.Description = courseVm.Description;

            _courserepo.Update(course);
            // Save changes to the database
            _courserepo.SaveChanges();
        }
    }
}
