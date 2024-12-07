using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace GraduationProject__FacuiltySystem__.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {

        IDepartmentRepository DepartmentRepository;

        public DepartmentController(IDepartmentRepository DepartmentRepository)
        {
            this.DepartmentRepository = DepartmentRepository;
        }
        public IActionResult Index()
        {
            var departments = DepartmentRepository.GetAll().ToList();
            return View(model: departments);
        }

        public IActionResult Create()
        {
            Department department = new Department();
            return View(model: department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {

                DepartmentRepository.Add(department);

                DepartmentRepository.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(model: department);

        }

        [ValidateAntiForgeryToken]
        public IActionResult Delete(int departmentId)
        {
            Department department = new Department() { DepartmentId = departmentId };
            DepartmentRepository.Delete(department);
            DepartmentRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int departmentId)
        {
            var department = DepartmentRepository.GetOne(expression: e => e.DepartmentId == departmentId).FirstOrDefault();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartmentRepository.Edit(department);
                DepartmentRepository.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }
    }
}
