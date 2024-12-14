using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using static System.Collections.Specialized.BitVector32;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class LecturesController : Controller
    {
        ILecturesRepository _lecturesRepository;
        ICourseRepository _courseRepository;
        public LecturesController(ILecturesRepository lecturesRepository, ICourseRepository courseRepository)
        {

            _lecturesRepository = lecturesRepository;
            _courseRepository = courseRepository;
        }

        //public IActionResult Index()
        //{
        //    var lecture = _lecturesRepository.GetAll();
        //    return View(lecture);
        //}

        public IActionResult Create()
        {
            var Course = _courseRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.CourseId.ToString() });
            ViewBag.Course = Course;
            var lecture = new Lectures();
            return View(lecture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lectures lecture)
        {
            if (ModelState.IsValid)
            {
                _lecturesRepository.Add(lecture);
                _lecturesRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        public IActionResult Delete(int id)
        {
            Lectures lectures = new Lectures() { LecturesId = id };
            _lecturesRepository.Delete(lectures);
            _lecturesRepository.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
