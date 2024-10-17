using Elearn.DAL.Models;
using Elearn.DAL.Repos.Abstract;
using Elearn.DAL.Repos.Implementation;
using ELearn.BLL.Services.Abstract;
using ELearn.BLL.ViewModels.CourseVM;
using ELearn.BLL.ViewModels.StudentVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.BLL.Services.Implementation
{
    public class StudentServices : IStudentServices

    {
        private readonly IStudentRepo _studentRepo;
        private readonly SignInManager<Student> _signInManager;
        private readonly UserManager<Student> _userManager;

        public StudentServices(IStudentRepo studentRepo, SignInManager<Student> signInManager, UserManager<Student> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _studentRepo = studentRepo;
        }
        public CreateStudentVM Add(CreateStudentVM courseVM)
        {
            var studentEntity = new Student
            {
                FullName = courseVM.FullName,
                Email = courseVM.Email,
                Password=courseVM.Password,
                UserName = courseVM.UserName,
            };

            _studentRepo.Create(studentEntity);
            _studentRepo.SaveChanges();
            return courseVM;
        }
        public void Delete(string id)
        {

            _studentRepo.Delete(id);
            _studentRepo.SaveChanges();
        }

        public IEnumerable<GetStudentVM> GetAll()
        {
            var studentsEntities = _studentRepo.GetAll();
            var studentVm = studentsEntities.Select(students => new GetStudentVM
            {
                Id = students.Id,
                FullName = students.FullName,
                Email = students.Email,
                UserName = students.UserName,

            });
            return studentVm;
        }

        public GetStudentVM GetById(string id)
        {
            var studentEntities = _studentRepo.GetById(id);
            if (studentEntities == null)
            {
                throw new KeyNotFoundException($"Course with id {id} not found.");
            }
            _studentRepo.SaveChanges();
            var studentVm = new GetStudentVM
            {
                Id = studentEntities.Id,
                FullName = studentEntities.FullName,
                UserName= studentEntities.UserName,
                Email = studentEntities.Email,

            };
            _studentRepo.SaveChanges();
            return studentVm;
           
          
        }
      

        public void Update(string id, EditStudentVm studentVm)
        {
            var student = _studentRepo.GetById(id);
            if (student == null)
            {
                throw new KeyNotFoundException($"Course with id {studentVm.Id} not found.");
            }

            student.Id = studentVm.Id;
            student.FullName = studentVm.FullName;
            student.Email = studentVm.Email;
            student.UserName = studentVm.UserName;
            student.Password = studentVm.Password;

           

            _studentRepo.Update(student);
            // Save changes to the database
            _studentRepo.SaveChanges();
        }

    }
}
