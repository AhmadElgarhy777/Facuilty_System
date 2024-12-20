using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Models;
using Utility;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.AdminRole},{SD.Empolyee}")]
    public class InquiryController : Controller
    {
        private readonly IInquiryRepositry inquiryRepositry;
        private readonly EmailSender emailSender;

        public InquiryController(IInquiryRepositry inquiryRepositry, EmailSender emailSender)
        {
            this.inquiryRepositry = inquiryRepositry;
            this.emailSender = emailSender;
        }

        // Action for displaying the contact form
        public IActionResult Index()
        {
           var inquirys= inquiryRepositry.GetAll().ToList();
            return View(inquirys);
        }
        public IActionResult Details(int Id)
        {
           var inquiry= inquiryRepositry.GetOne(expression:e=>e.Id==Id).FirstOrDefault();
            return View(inquiry);
        }

        public IActionResult Create(int Id) {
            var inquiry = inquiryRepositry.GetOne(expression: e => e.Id == Id).FirstOrDefault();
            ViewBag.Time = DateTime.Now;
            return View(inquiry);
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                if(inquiry.Status==EnumStatus.Unread) inquiry.Status = EnumStatus.Responded;
                else inquiry.Status = EnumStatus.Responded;
              

                inquiryRepositry.Edit(inquiry);
                inquiryRepositry.Commit();

                // Send the email
             

                await emailSender.SendEmailAsync(inquiry.StudentEmail, inquiry.Subject, inquiry.EmployeeResponse );

                TempData["message"] = "Your inquiry has been sent successfully!";
                return RedirectToAction("Details");
            }

            return View(inquiry);
        }

        
    }
}
