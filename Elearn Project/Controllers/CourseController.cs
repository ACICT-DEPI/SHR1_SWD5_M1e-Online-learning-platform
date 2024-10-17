using ELearn.BLL.Services.Abstract;
using ELearn.BLL.ViewModels.CourseVM;
using Microsoft.AspNetCore.Mvc;

namespace Elearn_Project.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices) 
        {
            _courseServices = courseServices;
        }
        public IActionResult Index()
        {
            var courses = _courseServices.GetAll();
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = _courseServices.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseVm courseVm)
        {
            if (ModelState.IsValid)
            {
                _courseServices.Add(courseVm);
                return RedirectToAction(nameof(Index));
            }
            return View(courseVm);
        }

        public IActionResult Edit(int id)
        {
            var course = _courseServices.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            var courseVm = new EditCourseVm
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description
            };
            return View(courseVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCourseVm courseVm)
        {
            if (id != courseVm.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _courseServices.Update( id,courseVm); 
                return RedirectToAction(nameof(Index));
            }
            return View(courseVm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseServices.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            _courseServices.Delete(id);

            return RedirectToAction(nameof(Index));

        }

        


    }
}
