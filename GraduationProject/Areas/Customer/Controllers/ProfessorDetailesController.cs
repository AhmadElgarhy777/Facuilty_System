using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProfessorDetailesController : Controller
    {
        private readonly IMemberRepository memberRepository;

        public ProfessorDetailesController( IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public IActionResult Index(string ProfID)
        {
            //var professor=await userManager.FindByIdAsync(ProfID);
           var professor=memberRepository.GetOne(expression:e => e.MemberId == ProfID, includeProp: [e => e.Department]).FirstOrDefault();

            ViewBag.age = DateTime.Today.Year - professor.BirthDate.Year;
            return View(professor);
        }
    }
}
