using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class EmpolyeeDetailesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmpolyeeDetailesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index(string EmpID)
        {
            //var professor=await userManager.FindByIdAsync(ProfID);
            var empolyee = employeeRepository.GetOne(expression: e => e.EmployeeId == EmpID).FirstOrDefault();

            ViewBag.age = DateTime.Today.Year - empolyee.BirthDate.Year;
            return View(empolyee);
        }
    }
}
