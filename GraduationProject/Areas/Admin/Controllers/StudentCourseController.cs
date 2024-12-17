using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using System.Linq.Expressions;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentCourseController : Controller
    {
        IStudentCourseRepository StudentCourseRepository;

        ICourseRepository CourseRepository;

        IStudentRepository StudentRepository;
        public StudentCourseController(IStudentCourseRepository StudentCourseRepository, ICourseRepository courseRepository , IStudentRepository StudentRepository)
        {
            this.StudentCourseRepository = StudentCourseRepository;

            this.CourseRepository = courseRepository;

            this.StudentRepository = StudentRepository;
        }
        public IActionResult Index(string studentId)
        {
             var studentcourse = StudentCourseRepository.GetAll(includeProp :[e => e.Course , e => e.Student , e => e.Course.Member], expression: e => e.StudentId == studentId).ToList();

            //var studentcourse = StudentCourseRepository.GetAll(includeProp: new Expression<Func<StudentCourse, object>>[] { e => e.Course, e => e.Course.Member, e => e.Student }, expression: e => e.StudentId == studentId).ToList();
            return View(model : studentcourse);
        }

        public IActionResult Create( int courseId)
        {
            var course = CourseRepository.GetAll( expression: e => e.CourseId == courseId).FirstOrDefault();

            return View(model : course);
        }

        [HttpPost]
        public IActionResult Create(string StudentSSN , int courseId)
        {
            var student = StudentRepository.GetAll(expression: e => e.SSN == StudentSSN).FirstOrDefault();

            var course = CourseRepository.GetAll(expression: e => e.CourseId == courseId).FirstOrDefault();

            var studentcourse = StudentCourseRepository.GetAll(expression: e => e.StudentId == student.StudentId);

            var studentcourse2 = studentcourse.Where(e => e.CourseId == courseId).FirstOrDefault();

            if (studentcourse2 == null && (student.Level == course.CourseLevel) )
            {
                var studentCourse = new StudentCourse
                {
                    StudentId = student.StudentId, 
                    CourseId = courseId
                };

                StudentCourseRepository.Add(studentCourse);
                StudentCourseRepository.Commit();
                TempData["Message"] = " The student is Added Successfully";
                return RedirectToAction(nameof(Resultpage));
            }

            else if (studentcourse2 != null)
            {
                TempData["Message"] = " The student is already assigned to this Course";
            }

            else if (studentcourse2 == null && (student.Level != course.CourseLevel))
            {
                TempData["Message"] = " The student level is not same as the Course level";
            }

            return RedirectToAction(nameof(Resultpage));
        }

        public IActionResult Resultpage()
        {
            string message = TempData["Message"] as string;
            ViewBag.Message = message;
            return View();
        }

        public IActionResult Delete(int courseId)
        {
            var course = CourseRepository.GetAll(expression: e => e.CourseId == courseId).FirstOrDefault();

            return View(model: course);
        }

        [HttpPost]
        public IActionResult Delete(string StudentSSN, int courseId)
        {
            var student = StudentRepository.GetAll(expression: e => e.SSN == StudentSSN).FirstOrDefault();

            var course = CourseRepository.GetAll(expression: e => e.CourseId == courseId).FirstOrDefault();

            var studentcourse = StudentCourseRepository.GetAll(expression: e => e.StudentId == student.StudentId);

            var studentcourse2 = studentcourse.Where(e => e.CourseId == courseId).FirstOrDefault();

            if (studentcourse2 != null && (studentcourse2.StudentFinalDegree == 0) )
            {
                var studentCourse = new StudentCourse
                {
                    StudentId = student.StudentId,
                    CourseId = courseId
                };

                StudentCourseRepository.Delete(studentcourse2);
                StudentCourseRepository.Commit();
                TempData["Message"] = " The student is Deleted Successfully";
                return RedirectToAction(nameof(Resultpage));
            }

            else if (studentcourse2 == null)
            {
                TempData["Message"] = " The student is Already not added to this course";
            }

            else if (studentcourse2 != null && (studentcourse2.StudentFinalDegree != 0))
            {
                TempData["Message"] = " The student has finished this course and get final degrees, cannot be deleted";
            }

            return RedirectToAction(nameof(Resultpage));
        }
    }
}
