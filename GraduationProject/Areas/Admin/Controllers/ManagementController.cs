using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;

namespace GraduationProject__FacuiltySystem__.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ManagementController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IStudentRepository studentRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IEmployeeRepository employeeRepository;
        public ManagementController(UserManager<IdentityUser> userManager, IStudentRepository studentRepository, IDepartmentRepository departmentRepository , IMemberRepository memberRepository , IEmployeeRepository employeeRepository)
        {
            this.userManager = userManager;
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
            this.memberRepository = memberRepository;
            this.memberRepository = memberRepository;
            this.employeeRepository = employeeRepository;
        }
        public IActionResult Index(string search = null, int page = 1)
        {
            int pageSize = 5;
            var totalProducts = studentRepository.GetAll([]).Count();
            ;
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page <= 0) page = 1;
            if (page > totalPages) page = totalPages;
            IQueryable<Student> students = studentRepository.GetAll([e => e.Department]);
            ;

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;


 
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                students = students.Where(e => e.SSN.Contains(search));  

                if (!students.Any())   
                {
                    ViewBag.ErrorMessage = "No students found with that SSN.";   
                }
            }
            students = students.Skip((page - 1) * pageSize).Take(pageSize);

            return View(students.ToList());
        }
        //Edit Student
        public IActionResult Edit(string Studentid)
        {
            ViewBag.EnumGender = (EnumGender[])Enum.GetValues(typeof(EnumGender));
            ViewBag.EnumLevel = (EnumLevel[])Enum.GetValues(typeof(EnumLevel));
            ViewBag.department = departmentRepository.GetAll().ToList();

            var students = studentRepository.GetOne([e => e.Department], e => e.StudentId == Studentid).FirstOrDefault();
            return View(students);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student, IFormFile ImgUrl)
        {
            var oldproduct = studentRepository.GetOne([], e => e.StudentId == student.StudentId, false).FirstOrDefault();

            if (oldproduct == null)
            {
                return RedirectToAction("");
            }
           

                if (ImgUrl != null && ImgUrl.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", fileName);
                    var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", oldproduct.ImgUrl);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        ImgUrl.CopyTo(stream);
                    }
                    if (System.IO.File.Exists(oldfilePath))
                    {
                        System.IO.File.Delete(oldfilePath);
                    }
                    student.ImgUrl = fileName;
                }
                else
                {
                    student.ImgUrl = oldproduct.ImgUrl;
                }

                var newUser = await userManager.FindByIdAsync(student.StudentId);
                newUser.Email = student.Email;
            newUser.UserName = student.FName + "_" + student.MName + "_" + student.LName;
               
                //newUser.Address = student.Address;
                var result = await userManager.UpdateAsync(newUser);
                if (result.Succeeded)
                {
                    studentRepository.Edit(student);
                    studentRepository.Commit();
                    TempData["success"] = "Edited student successfuly";

                    return RedirectToAction("Index", "Management", new { area = "Admin" });
                }
               
                    TempData["error"] = "the student Email are required";
                
                return View(student);
                
            
        }
        public async Task<IActionResult> Delete(string id)
        {
            var student = studentRepository.GetAll().FirstOrDefault(e => e.StudentId == id);
            var newUser = await userManager.FindByIdAsync(id);
            var result= await userManager.DeleteAsync(newUser);
            if (result.Succeeded)
            {
                studentRepository.Delete(student);
                studentRepository.Commit();
                TempData["success"] = "Delete student successfuly";
                return RedirectToAction("Index");
            }else

                TempData["error"] = "the student Email are required";
            return RedirectToAction("Index");
        }

        public IActionResult Index_Professor(int page = 1, string search = null)
        {
 
            int pageSize = 5;
            var totalProducts = memberRepository.GetAll([]).Count();
            ;
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page <= 0) page = 1;
            if (page > totalPages) page = totalPages;
            IQueryable<Member> Professors = memberRepository.GetAll([e => e.Department], e => e.IsProfessor == 1);
            ;

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                Professors = Professors.Where(e => e.SSN.Contains(search));

                if (!Professors.Any())
                {
                    ViewBag.ErrorMessage = "No Professors found with that SSN.";
                }
            }
            Professors = Professors.Skip((page - 1) * pageSize).Take(pageSize);

            return View(Professors.ToList());

        }
        public IActionResult Edit_Professor(string Memberid)
        {
            ViewBag.EnumGender = (EnumGender[])Enum.GetValues(typeof(EnumGender));
            ViewBag.EnumLevel = (EnumLevel[])Enum.GetValues(typeof(EnumLevel));
            ViewBag.department = departmentRepository.GetAll().ToList();

            var members = memberRepository.GetOne([e => e.Department], e => e.MemberId == Memberid).FirstOrDefault();
            return View(members);
        }
        [HttpPost]
        public async Task<IActionResult> Edit_Professor(Member member, IFormFile ImgUrl)
        {
            var oldproduct = memberRepository.GetOne([], e => e.MemberId == member.MemberId, false).FirstOrDefault();

            if (oldproduct == null)
            {
                return RedirectToAction("Index_Professor");
            }
           
                if (ImgUrl != null && ImgUrl.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", fileName);
                    var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", oldproduct.ImgUrl);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        ImgUrl.CopyTo(stream);
                    }
                    if (System.IO.File.Exists(oldfilePath))
                    {
                        System.IO.File.Delete(oldfilePath);
                    }
                    member.ImgUrl = fileName;
                }
                else
                {
                    member.ImgUrl = oldproduct.ImgUrl;
                }
                var newUser = await userManager.FindByIdAsync(member.MemberId);
                newUser.Email = member.Email;
            newUser.UserName = member.FName + "_" + member.MName + "_" + member.LName;
              
            //newUser.Address = member.Address;
                var result = await userManager.UpdateAsync(newUser);
                if (result.Succeeded)
                {

                    memberRepository.Edit(member);
                    memberRepository.Commit();
                    TempData["success"] = "Edited Professor successfuly";
                    return RedirectToAction("Index_Professor", "Management", new { area = "Admin" });
                }
              
                    TempData["error"] = "the student Email are required";

            return RedirectToAction("Edit_Professor", "Management", new { area = "Admin" });



        }
        public async Task<IActionResult> Delete_Professor(string id)
        {
            var member = memberRepository.GetAll().FirstOrDefault(e => e.MemberId == id);
            var newUser = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(newUser);
            if (result.Succeeded)
            {
                memberRepository.Delete(member);
                memberRepository.Commit();
                TempData["success"] = "Delete Professor successfuly";
                return RedirectToAction("Index_Professor");
            }
            else

                TempData["error"] = "the Professor Email are Reruired";
            return RedirectToAction("Index_Professor");
        }







        public IActionResult Index_Assistant(int page = 1, string search = null)
        {
 

            int pageSize = 5;
            var totalProducts = memberRepository.GetAll([]).Count();
            ;
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page <= 0) page = 1;
            if (page > totalPages) page = totalPages;
            IQueryable<Member> Assistants = memberRepository.GetAll([e => e.Department], e => e.IsProfessor == 0);
            ;

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                Assistants = Assistants.Where(e => e.SSN.Contains(search));

                if (!Assistants.Any())
                {
                    ViewBag.ErrorMessage = "No Assistants found with that SSN.";
                }
            }
            Assistants = Assistants.Skip((page - 1) * pageSize).Take(pageSize);

            return View(Assistants.ToList());

        }
        public IActionResult Edit_Assistant(string Memberid)
        {
            ViewBag.EnumGender = (EnumGender[])Enum.GetValues(typeof(EnumGender));
            ViewBag.EnumLevel = (EnumLevel[])Enum.GetValues(typeof(EnumLevel));
            ViewBag.department = departmentRepository.GetAll().ToList();

            var members = memberRepository.GetOne([e => e.Department], e => e.MemberId == Memberid).FirstOrDefault();
            return View(members);
        }
        [HttpPost]
        public async Task<IActionResult> Edit_Assistant(Member member, IFormFile ImgUrl)
        {
            var oldproduct = memberRepository.GetOne([], e => e.MemberId == member.MemberId, false).FirstOrDefault();

            if (oldproduct == null)
            {
                return RedirectToAction("Index_Assistant");
            }

            if (ImgUrl != null && ImgUrl.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", fileName);
                var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", oldproduct.ImgUrl);

                using (var stream = System.IO.File.Create(filePath))
                {
                    ImgUrl.CopyTo(stream);
                }
                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }
                member.ImgUrl = fileName;
            }
            else
            {
                member.ImgUrl = oldproduct.ImgUrl;
            }
            var newUser = await userManager.FindByIdAsync(member.MemberId);
            newUser.Email = member.Email;
            newUser.UserName = member.FName + "_" + member.MName + "_" + member.LName;
         
            //newUser.Address = member.Address;
            var result = await userManager.UpdateAsync(newUser);
            if (result.Succeeded)
            {
                memberRepository.Edit(member);
                memberRepository.Commit();
                TempData["success"] = "Edited Assistant successfuly";
                return RedirectToAction("Index_Assistant", "Management", new { area = "Admin" });
            }
            TempData["error"] = "the student Email are required";

            return RedirectToAction("Edit_Professor", "Management", new { area = "Admin" });


        }
        public async Task<IActionResult> Delete_Assistant(string id)
        {
            var member = memberRepository.GetAll().FirstOrDefault(e => e.MemberId == id);
            var newUser = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(newUser);
            if (result.Succeeded)
            {
                memberRepository.Delete(member);
                memberRepository.Commit();
                TempData["success"] = "Delete Assistant successfuly";
                return RedirectToAction("Index_Assistant");
            }
            else

                TempData["error"] = "the Assistant Email are Reruired";
            return RedirectToAction("Index_Assistant");

        }







        public IActionResult Index_Empolyee(int page = 1, string search = null)
        {
 

            int pageSize = 5;
            var totalProducts = memberRepository.GetAll([]).Count();
            ;
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page <= 0) page = 1;
            if (page > totalPages) page = totalPages;
            IQueryable<Employee> employees = employeeRepository.GetAll();
            ;

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                employees = employees.Where(e => e.SSN.Contains(search));

                if (!employees.Any())
                {
                    ViewBag.ErrorMessage = "No Employees found with that SSN.";
                }
            }
            employees = employees.Skip((page - 1) * pageSize).Take(pageSize);


            return View(employees.ToList());

        }
        public IActionResult Edit_Empolyee(string Employeeid) 
        {
            ViewBag.EnumGender = (EnumGender[])Enum.GetValues(typeof(EnumGender));
            ViewBag.EnumLevel = (EnumLevel[])Enum.GetValues(typeof(EnumLevel));
            ViewBag.department = departmentRepository.GetAll().ToList();

            var members = employeeRepository.GetOne([], e => e.EmployeeId == Employeeid).FirstOrDefault();
            return View(members);
        }
        [HttpPost]
        public async Task<IActionResult> Edit_Empolyee(Employee employee, IFormFile ImgUrl)
        {
            var oldproduct = employeeRepository.GetOne([], e => e.EmployeeId == employee.EmployeeId, false).FirstOrDefault();

            if (oldproduct == null)
            {
                return RedirectToAction("Index_Empolyee");
            }

            if (ImgUrl != null && ImgUrl.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", fileName);
                var oldfilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", oldproduct.ImgUrl);

                using (var stream = System.IO.File.Create(filePath))
                {
                    ImgUrl.CopyTo(stream);
                }
                if (System.IO.File.Exists(oldfilePath))
                {
                    System.IO.File.Delete(oldfilePath);
                }
                employee.ImgUrl = fileName;
            }
            else
            {
                employee.ImgUrl = oldproduct.ImgUrl;
            }
            var newUser = await userManager.FindByIdAsync(employee.EmployeeId);
            newUser.Email = employee.Email;
            newUser.UserName = employee.FName + "_" + employee.MName + "_" + employee.LName;
          
            //newUser.Address = member.Address;
            var result = await userManager.UpdateAsync(newUser);
            if (result.Succeeded)
            {
                employeeRepository.Edit(employee);
                employeeRepository.Commit();
                TempData["success"] = "Edited Employee successfuly";
                return RedirectToAction("Index_Empolyee", "Management", new { area = "Admin" });
            }
            TempData["error"] = "the student Email are required";

            return RedirectToAction("Edit_Empolyee", "Management", new { area = "Admin" });

        }
        public async Task<IActionResult> Delete_Empolyee(string id)
        {
            var employee = employeeRepository.GetAll().FirstOrDefault(e => e.EmployeeId == id);
            var newUser = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(newUser);
            if (result.Succeeded)
            {
                employeeRepository.Delete(employee);
                employeeRepository.Commit();
                TempData["success"] = "Delete Employee successfuly";
                return RedirectToAction("Index_Empolyee");
            }
            TempData["error"] = "the Empolyee Email are Reruired";
            return RedirectToAction("Index_Empolyee");

        }


    }
}
