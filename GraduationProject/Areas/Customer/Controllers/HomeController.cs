using Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    //[Authorize(Policy = "Student")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository studentRepository;
        private readonly IMemberRepository memberRepository;

        public HomeController(ILogger<HomeController> logger , IStudentRepository studentRepository , IMemberRepository memberRepository)
        {
            _logger = logger;
            this.studentRepository = studentRepository;
            this.memberRepository = memberRepository;

        }

        public IActionResult Index()
        {
            ViewBag.professors = memberRepository.GetAll([e => e.Department], e => e.IsProfessor == 1); 
            var students = studentRepository.GetOne([e => e.Department],e=>e.SSN == "12345678910111").FirstOrDefault();
            return View(students);
        }

        public IActionResult Privacy()
        {
           return View();
        }
        public IActionResult About_Faculty()
        {

             return View( );
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
