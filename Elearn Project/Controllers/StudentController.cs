using Elearn.DAL.Models;
using ELearn.BLL.Services.Abstract;
using ELearn.BLL.Services.Implementation;
using ELearn.BLL.ViewModels.CourseVM;
using ELearn.BLL.ViewModels.StudentVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Elearn_Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public IActionResult Index()
        {
            var students = _studentServices.GetAll();
            return View(students);
        }

        public IActionResult Details(string id)
        {
            var students = _studentServices.GetById(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                _studentServices.Add(studentVM);
                return RedirectToAction(nameof(Index));
            }
            return View(studentVM);
        }

        public IActionResult Edit(string id)
        {
            var students = _studentServices.GetById(id);
            if (students == null)
            {
                return NotFound();
            }

            var studentVm = new EditStudentVm
            {
                Id = students.Id,
                FullName = students.FullName,
                Email = students.Email,
                UserName = students.UserName,
                Password = students.Password
            };

            return View(studentVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, EditStudentVm studentVm)
        {
            if (id != studentVm.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _studentServices.Update(id, studentVm);
                return RedirectToAction(nameof(Index));
            }
            return View(studentVm);
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var course = _studentServices.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            _studentServices.Delete(id);

            return RedirectToAction(nameof(Index));

        }
        //public IActionResult Login()
        //{
        //    return View("Login");
        //}
        //[HttpPost]
        //public async Task<IActionResult> SaveLogin(LoginVM userViewModel)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        //check found
        //        Student student = await _studentServices.GetByEmailAsync(userViewModel.Email);
        //        if (student != null)
        //        {
        //            bool found = await UserManager.CheckPasswordAsync(appUser, userViewModel.Password);
        //            if (found)
        //            {
        //                List<Claim> claims = new List<Claim>();//clime=>Type And Value
        //                claims.Add(new Claim("userAddress", appUser.Address));
        //                await signInManager.SignInWithClaimsAsync(appUser, userViewModel.RememdbrrMe, claims);
        //                // await signInManager.SignInAsync(appUser, userViewModel.RememdbrrMe);
        //                return RedirectToAction("Index", "Department");
        //            }

        //        }
        //        ModelState.AddModelError("", "UserName OR Password Wrong");
        //        //creat cookie
        //    }

        //    return View("Longin", userViewModel);

        //}


        //public async Task<IActionResult> SignOut()
        //{
        //    await signInManager.SignOutAsync();
        //    return View("Longin");
        //}


    }
}

