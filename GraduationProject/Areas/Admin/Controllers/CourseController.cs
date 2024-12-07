using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CourseController : Controller
    {
        ICourseRepository CourseRepository;

        IDepartmentRepository DepartmentRepository;

        IMemberRepository MemberRepository;
        public CourseController(ICourseRepository CourseRepository, IDepartmentRepository DepartmentRepository, IMemberRepository memberRepository)
        {
            this.CourseRepository = CourseRepository;

            this.DepartmentRepository = DepartmentRepository;

            this.MemberRepository = memberRepository;
        }
        public IActionResult Index()
        {
            var courses = CourseRepository.GetAll([e => e.Department, e => e.Member]).ToList();
            return View(model: courses);
        }

        public IActionResult Create()
        {
            Course course = new Course();

            ViewBag.departments = DepartmentRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.DepartmentId.ToString() });

            ViewBag.members = MemberRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.FName + e.MName + e.LName, Value = e.MemberId.ToString() });


            return View(model: course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {

                CourseRepository.Add(course);

                CourseRepository.Commit();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.departments = DepartmentRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.DepartmentId.ToString() });

            ViewBag.members = MemberRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.FName + e.MName + e.LName, Value = e.MemberId.ToString() });

            return View(model: course);

        }

        public IActionResult Delete(int courseId)
        {
            Course course = new Course() { CourseId = courseId };
            CourseRepository.Delete(course);
            CourseRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int courseId)
        {
            var course = CourseRepository.GetOne(expression: e => e.CourseId == courseId).FirstOrDefault();

            ViewBag.departments = DepartmentRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.DepartmentId.ToString() });

            ViewBag.members = MemberRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.FName + e.MName + e.LName, Value = e.MemberId.ToString() });

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                CourseRepository.Commit();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.departments = DepartmentRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.DepartmentId.ToString() });

            ViewBag.members = MemberRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.FName + e.MName + e.LName, Value = e.MemberId.ToString() });

            return View(course);

        }
    }
}
