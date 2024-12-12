using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProfessorDetailes : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMemberRepository memberRepository;

        public ProfessorDetailes(UserManager<IdentityUser>userManager, IMemberRepository memberRepository)
        {
            this.userManager = userManager;
            this.memberRepository = memberRepository;
        }

        public IActionResult Index(string ProfID)
        {
            //var professor=await userManager.FindByIdAsync(ProfID);
           var professor=memberRepository.GetOne(expression:e => e.MemberId == ProfID,includeProp: [e => e.Department]).FirstOrDefault();

            ViewBag.age = DateTime.Today.Year - professor.BirthDate.Year;
            return View(professor);
        }
    }
}
