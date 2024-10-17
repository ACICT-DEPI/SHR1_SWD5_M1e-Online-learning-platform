using Elearn.DAL.Models;
using ELearn.BLL.ViewModels.StudentVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Elearn_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        public AccountController(UserManager<Student> userManager, SignInManager<Student> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateStudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                var student = await _userManager.FindByEmailAsync(studentVM.Email);
                if (student is null)
                {
                    student = new Student()
                    {
                        FullName = studentVM.FullName,
                        UserName = studentVM.UserName,
                        Email = studentVM.Email,
                        Password = studentVM.Password

                    };
                    var res = await _userManager.CreateAsync(student, studentVM.Password);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in res.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }
            }
            ModelState.AddModelError("", "InValid Account");
            return View(studentVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var student = await _userManager.FindByEmailAsync(loginVM.Email);
                if (student is not null)
                {
                    var check = await _userManager.CheckPasswordAsync(student, loginVM.Password);
                    if (check)
                    {
                        var res = await _signInManager.PasswordSignInAsync(student, student.Password, student.RememberMe, lockoutOnFailure: true);
                        if (res.IsLockedOut)
                        {
                            ModelState.AddModelError("", "Your Account is Locked for 1 min");
                        }
                        if (res.Succeeded) 
                        {
                            return RedirectToAction("Index", "Course");
                        }
                    }
                 
                }

               
            }
            return View(loginVM);


        }
        public new async Task<IActionResult> SiginOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}