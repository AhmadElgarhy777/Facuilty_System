using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Configuration;

namespace GraduationProject.Areas.Admin.Controllers
{      [Area("Admin")]
    public class TimetableController : Controller
    {
        private readonly ITimetableRepository timetableRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly  ISectionRepository sectionRepository;
        public TimetableController(ITimetableRepository timetableRepository , ISectionRepository sectionRepository, ILectureRepository lectureRepository)
        {
            this.timetableRepository = timetableRepository;
            this.sectionRepository = sectionRepository;
            this.lectureRepository = lectureRepository;
        }
        public IActionResult Index()
        {
            var timetables = timetableRepository.GetAll([e=>e.Section , e=>e.Lecture], e=>e.isDay == true).ToList();
            return View(timetables);
        }
        public IActionResult Create(string day)
        {

            ViewBag.day = day; 
             ViewBag.sections = sectionRepository.GetAll()
                .ToList();
            ViewBag.lectures = lectureRepository.GetAll().ToList();

          
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Timetable timetable)
        {
            timetableRepository.Add(timetable);
            timetableRepository.Commit(); 


            return RedirectToAction("index");
        }

        public IActionResult Edit(int Timetableid)
        {
            var timetable = timetableRepository.GetOne([], e => e.TimetableId == Timetableid).FirstOrDefault();
            ViewBag.day = timetable.Day; 
            ViewBag.sections = sectionRepository.GetAll()
               .ToList();
            ViewBag.lectures = lectureRepository.GetAll().ToList();

            return View(timetable);
        }
        [HttpPost]
        public IActionResult Edit(Timetable Timetable )
        {
            if (Timetable.Day == null)
            {
                Timetable.Day = ViewBag.day; // Set a default value if Day is null
            }
            timetableRepository.Edit(Timetable);
            timetableRepository.Commit();
              return RedirectToAction("Index");
        }
        public IActionResult Delete(int Timetableid)
        {
            var timetableday = timetableRepository.GetOne([], e => e.TimetableId == Timetableid).FirstOrDefault();
            timetableRepository.Delete(timetableday);
            timetableRepository.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult Details(string  day)
        {
            ViewBag.day = day; 
        var timetableday =     timetableRepository.GetAll([e=>e.Lecture , e=>e.Section],e=>e.Day ==day).ToList();
            return View(timetableday);
        }
    }
}
