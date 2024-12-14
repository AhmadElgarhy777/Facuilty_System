using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AssistantController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMemberRepository memberRepository;

        public AssistantController(UserManager<IdentityUser> userManager, IMemberRepository memberRepository)
        {
            this.userManager = userManager;
            this.memberRepository = memberRepository;
        }

        public IActionResult Index(string AssistantId)
        {
            var Assistant = memberRepository.GetOne(expression: e => e.MemberId == AssistantId, includeProp: [e => e.Department]).FirstOrDefault();

            ViewBag.age = DateTime.Today.Year - Assistant.BirthDate.Year;
            return View(Assistant);
        }
    }
}
