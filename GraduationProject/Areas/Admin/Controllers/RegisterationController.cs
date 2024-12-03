using Models;
using Microsoft.AspNetCore.Identity;
using Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Utility;

namespace GraduationProject__FacuiltySystem__.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RegisterationController : Controller
    {
        private readonly UserManager<IdentityUser> usermanger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signinmanager;

        public RegisterationController(UserManager<IdentityUser> usermanger,RoleManager<IdentityRole> roleManager ,SignInManager<IdentityUser> signinmanager)
        {
            this.usermanger = usermanger;
            this.roleManager = roleManager;
            this.signinmanager = signinmanager;
        }


        public async Task<IActionResult> AddAdmin()
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new(SD.AdminRole));
                await roleManager.CreateAsync(new(SD.Professor));
                await roleManager.CreateAsync(new(SD.Asseitant));
                await roleManager.CreateAsync(new(SD.Empolyee));

            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> AddAdmin(AdminVM admin)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new()
                {
                    UserName = admin.Name,
                    Email=admin.Email,

                };
                var result =await usermanger.CreateAsync(applicationUser, admin.Password);
                if (result.Succeeded)
                {
                    TempData["message"] = $"The admin {admin.Name} is added sucsesufuly ";
                    await usermanger.AddToRoleAsync(applicationUser, SD.AdminRole);
                    return View();
                }
                else
                    ModelState.AddModelError("Password", "error-your pasword must confirm the ideal...");

            }
            return View(admin);
        }
    }
}
