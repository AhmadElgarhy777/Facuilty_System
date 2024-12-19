using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Models;
using Models.ViewModels;
using System.Linq.Expressions;
using Utility;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.AdminRole},{SD.Professor},{SD.Student}")]

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

        public IActionResult Resultpage2()
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

        public IActionResult Degrees(string studentId , int courseId)
        {
            var studentcourse = StudentCourseRepository.GetAll(includeProp: [e => e.Course] , expression: e => e.StudentId == studentId);

            var studentcourse2 = studentcourse.Where(e => e.CourseId == courseId).FirstOrDefault();

            return View(model: studentcourse2);
        }

        public IActionResult AddDegrees(string studentId, int courseId)
        {
            var studentcourse = StudentCourseRepository.GetAll( includeProp: [e => e.Course , e => e.Student] ,expression: e => e.StudentId == studentId);

            var studentcourse2 = studentcourse.Where(e => e.CourseId == courseId).FirstOrDefault();

            return View(model: studentcourse2);
        }

        [HttpPost]
        public IActionResult AddDegrees(StudentCourse studentcourse)
        {
            var course = CourseRepository.GetAll(expression: e => e.CourseId == studentcourse.CourseId).FirstOrDefault();
            if (
                   studentcourse.StudentAttendancedegree > course.AttendanceDegree
                || studentcourse.StudentMidTermDegree > course.MidTermDegree
                || studentcourse.StudentFinalDegree > course.FinalDegree
                || studentcourse.StudentOralDegree > course.OralDegree
                || studentcourse.StudentPracticalDegree > course.PracticalDegree
                )
            {
                TempData["Message"] = " Student degree must be not more than Exam degree";
                return RedirectToAction(nameof(Resultpage2));

            }
            else
            {
                var studentcourse2 = StudentCourseRepository.GetAll(tracked : false).FirstOrDefault();
                studentcourse.StudentCourseId = studentcourse2.StudentCourseId;
                studentcourse.Degree = studentcourse.StudentFinalDegree + studentcourse.StudentMidTermDegree + studentcourse.StudentOralDegree + studentcourse.StudentPracticalDegree + studentcourse.StudentAttendancedegree;

                if (studentcourse.Degree >= (0.9*course.Degree))
                    studentcourse.Grade = 'A';
                else if (studentcourse.Degree >= (0.75*course.Degree))
                    studentcourse.Grade = 'B';
                else if (studentcourse.Degree >= (0.6*course.Degree))
                    studentcourse.Grade = 'C';
                else if (studentcourse.Degree >= (0.5*course.Degree))
                    studentcourse.Grade = 'D';

                else 
                    studentcourse.Grade = 'F';

                StudentCourseRepository.Edit(studentcourse);
                CourseRepository.Commit();
                TempData["Message"] = " Degrees added successfully";
                return RedirectToAction(nameof(Resultpage2));

            }

        }
    }
}
