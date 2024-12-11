using DataAccess.Repository;
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
        public IActionResult Index(int page = 1, string search = null)
        {
             int pageSize = 5;
            var totalProducts = DepartmentRepository.GetAll([]).Count();
            ;
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            if (page <= 0) page = 1;
            if (page > totalPages) page = totalPages;
            IQueryable<Department> departments = DepartmentRepository.GetAll();
            ;

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;


            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                departments = departments.Where(e => e.Name.Contains(search));

                if (!departments.Any())
                {
                    ViewBag.ErrorMessage = "No department found with that Name.";
                }
            }
            departments = departments.Skip((page - 1) * pageSize).Take(pageSize);

            return View(model: departments.ToList());
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
