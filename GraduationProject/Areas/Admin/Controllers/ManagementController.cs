using DataAccess.Repository;
using DataAccess.Repository.IRepository;
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
        private readonly IStudentRepository studentRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IEmployeeRepository employeeRepository;
        public ManagementController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository , IMemberRepository memberRepository , IEmployeeRepository employeeRepository)
        {
            this.studentRepository = studentRepository;
            this.departmentRepository = departmentRepository;
            this.memberRepository = memberRepository;
            this.memberRepository = memberRepository;
            this.employeeRepository = employeeRepository;
        }
        public IActionResult Index(string search = null, int page = 1)
        {
            var students = studentRepository.GetAll([e => e.Department]);   

            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                students = students.Where(e => e.SSN.Contains(search));  

                if (!students.Any())   
                {
                    ViewBag.ErrorMessage = "No students found with that SSN.";   
                }
            }

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
        public IActionResult Edit(Student student, IFormFile ImgUrl)
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
 
            studentRepository.Edit(student);
            studentRepository.Commit();
            TempData["success"] = "Edited student successfuly";
             return RedirectToAction("Index", "Management", new { area = "Admin" });
            }
        public IActionResult Delete(string id)
        {
            var student = studentRepository.GetAll().FirstOrDefault(e => e.StudentId == id);
            studentRepository.Delete(student);
            studentRepository.Commit();
            TempData["success"] = "Delete student successfuly";
            return RedirectToAction("Index");

        }
        
        public IActionResult Index_Professor(string search = null)
        {
            var students = memberRepository.GetAll([e => e.Department], e => e.IsProfessor == 1);
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                students = students.Where(e => e.SSN.Contains(search));

                if (!students.Any())
                {
                    ViewBag.ErrorMessage = "No Professors found with that SSN.";
                }
            }

            return View(students.ToList());

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
        public IActionResult Edit_Professor(Member member, IFormFile ImgUrl)
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

            memberRepository.Edit(member);
            memberRepository.Commit();
            TempData["success"] = "Edited Professor successfuly";
            return RedirectToAction("Index_Professor", "Management", new { area = "Admin" });
        }
        public IActionResult Delete_Professor(string id)
        {
            var member = memberRepository.GetAll().FirstOrDefault(e => e.MemberId == id);
            memberRepository.Delete(member);
            memberRepository.Commit();
            TempData["success"] = "Delete Professor successfuly";
            return RedirectToAction("Index_Professor");

        }







        public IActionResult Index_Assistant(string search = null)
        {
            var students = memberRepository.GetAll([e => e.Department] , e=>e.IsProfessor==0);
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                students = students.Where(e => e.SSN.Contains(search));

                if (!students.Any())
                {
                    ViewBag.ErrorMessage = "No Assistants found with that SSN.";
                }
            }

            return View(students.ToList());

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
        public IActionResult Edit_Assistant(Member member, IFormFile ImgUrl)
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

            memberRepository.Edit(member);
            memberRepository.Commit();
            TempData["success"] = "Edited Assistant successfuly";
            return RedirectToAction("Index_Assistant", "Management", new { area = "Admin" });
        }
        public IActionResult Delete_Assistant(string id)
        {
            var member = memberRepository.GetAll().FirstOrDefault(e => e.MemberId == id);
            memberRepository.Delete(member);
            memberRepository.Commit();
            TempData["success"] = "Delete Assistant successfuly";
            return RedirectToAction("Index_Assistant");

        }







        public IActionResult Index_Empolyee(string search = null)
        {
            var employees = employeeRepository.GetAll(); if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                employees = employees.Where(e => e.SSN.Contains(search));

                if (!employees.Any())
                {
                    ViewBag.ErrorMessage = "No Employees found with that SSN.";
                }
            }


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
        public IActionResult Edit_Empolyee(Employee employee, IFormFile ImgUrl)
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

            employeeRepository.Edit(employee);
            employeeRepository.Commit();
            TempData["success"] = "Edited Employee successfuly";
            return RedirectToAction("Index_Empolyee", "Management", new { area = "Admin" });
        }
        public IActionResult Delete_Empolyee(string id)
        {
            var employee = employeeRepository.GetAll().FirstOrDefault(e => e.EmployeeId == id);
            employeeRepository.Delete(employee);
            employeeRepository.Commit();
            TempData["success"] = "Delete Employee successfuly";
            return RedirectToAction("Index_Empolyee");

        }


    }
}
