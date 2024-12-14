using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class StudentDetailes : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMemberRepository memberRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITimetableRepository timetableRepository;
        private readonly ILectureRepository lectureRepository;

        public StudentDetailes(UserManager<IdentityUser> userManager, IStudentRepository studentRepository, IMemberRepository memberRepository , ITimetableRepository timetableRepository , ILectureRepository lectureRepository)
        {
            this.userManager = userManager;
            this.studentRepository = studentRepository;
            this.memberRepository = memberRepository;
            this.timetableRepository = timetableRepository;
            this.lectureRepository = lectureRepository;
        }

        public IActionResult Index(string StudentID)
        {


            ViewBag.Lectures = lectureRepository.GetAll()
                                       .ToList();

             var student = studentRepository.GetOne([e => e.Department], e => e.StudentId == StudentID).FirstOrDefault();
            ViewBag.professors = memberRepository.GetAll([e => e.Department], e => e.IsProfessor == 1);
           ViewBag.timetable = timetableRepository.GetAll([e=>e.Lecture , e=>e.Section] ).ToList();
            return View(student);
        }
    }
}