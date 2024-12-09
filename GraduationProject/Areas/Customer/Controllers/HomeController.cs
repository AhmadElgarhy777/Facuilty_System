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

        public HomeController(ILogger<HomeController> logger , IStudentRepository studentRepository)
        {
            _logger = logger;
            this.studentRepository = studentRepository;

        }

        public IActionResult Index()
        {
            var students = studentRepository.GetOne([e => e.Department],e=>e.SSN == "123-45-6").FirstOrDefault();
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
