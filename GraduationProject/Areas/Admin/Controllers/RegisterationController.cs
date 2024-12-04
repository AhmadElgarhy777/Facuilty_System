using Models;
using Microsoft.AspNetCore.Identity;
using Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Utility;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProject__FacuiltySystem__.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RegisterationController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly UserManager<IdentityUser> usermanger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signinmanager;

        public RegisterationController(IStudentRepository studentRepository,IDepartmentRepository departmentRepository ,UserManager<IdentityUser> usermanger,RoleManager<IdentityRole> roleManager ,SignInManager<IdentityUser> signinmanager)
        {
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
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
                await roleManager.CreateAsync(new(SD.Student));

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
                    TempData["message"] = $"The admin is added sucsesufuly ";
                    await usermanger.AddToRoleAsync(applicationUser, SD.AdminRole);
                    return View();
                }
                else
                    ModelState.AddModelError("Password", "error-your pasword must confirm the ideal...");

            }
            return View(admin);
        }
        public IActionResult AddStudent( )
        {
            
            ViewBag.EnumGender = (EnumGender[]) Enum.GetValues(typeof(EnumGender));
            ViewBag.EnumLevel = (EnumLevel[]) Enum.GetValues(typeof(EnumLevel));
            var department=departmentRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name , Value = e.DepartmentId.ToString() });
            ViewBag.department = department;


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> AddStudent(StudentVM student)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new()
                {
                    UserName=student.FName+"_"+student.MName+"_"+ student.LName,
                    Email=student.Email,
                    Address=student.Address,
                };
                var result = await usermanger.CreateAsync(applicationUser,student.SSN);

                if (result.Succeeded)
                {
                    await usermanger.AddToRoleAsync(applicationUser, SD.Student);
               
                    Student studentinstance = new()
                {
                    StudentId =applicationUser.Id,
                    SSN=student.SSN,
                    FName=student.FName,    
                    MName=student.MName,
                    LName=student.LName,
                   Email=student.Email,
                   Address=student.Address,
                   Gender=student.Gender,
                   BirthDate=student.BirthDate,
                   Level=student.Level,
                   Nationailty=student.Nationailty,
                   DepartmentId=student.DepartmentId

                };
                    studentRepository.Add(studentinstance);
                    studentRepository.Commit();
                    TempData["message"] = $"The Student is added sucsesufuly ";
                    ViewBag.EnumGender = (EnumGender[])Enum.GetValues(typeof(EnumGender));
                    ViewBag.EnumLevel = (EnumLevel[])Enum.GetValues(typeof(EnumLevel));
                    var department = departmentRepository.GetAll().ToList().Select(e => new SelectListItem { Text = e.Name, Value = e.DepartmentId.ToString() });
                    ViewBag.department = department;
                    return View();

                }
                else
                {
                    ModelState.AddModelError("FName", "this user name is already exist ");
                }

            }
            ViewBag.EnumGender = (EnumGender[])Enum.GetValues(typeof(EnumGender));
            ViewBag.EnumLevel = (EnumLevel[])Enum.GetValues(typeof(EnumLevel));

            return View(student);
        }
    }

}
