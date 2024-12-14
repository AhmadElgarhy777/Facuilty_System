using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SectionsController : Controller
    {
        ISectionsRepository _sectionsRepository;
        ICourseRepository _courseRepository;
        public SectionsController(ISectionsRepository sectionsRepository,ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _sectionsRepository = sectionsRepository;
        }

        //public IActionResult Index()
        //{
        //    var sections = _sectionsRepository.GetAll();
        //    return View(sections);
        //}

        public IActionResult Create()
        {
            var Course = _courseRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.CourseId.ToString() });
            ViewBag.Course = Course;
            var section = new Sections();
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sections sections)
        {
            if (ModelState.IsValid)
            {
                _sectionsRepository.Add(sections);
                _sectionsRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(sections);
        }

        public IActionResult Delete(int id)
        {
            Sections sections = new Sections() { SectionsId = id };
            _sectionsRepository.Delete(sections);
            _sectionsRepository.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
