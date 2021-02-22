using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Controllers
{
    public class StudentController : Controller
    {
        private CoreContext context;

        public StudentController(CoreContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Student");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(int id)
        {
            var Students = context.Students
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName).ToList();

            ViewBag.AccessLevel = id;
            // bind Students to view
            return View(Students);
        }

        public IActionResult Details(int id)
        {
            var Student = context.Students.Find(id);
            ViewBag.AccessLevel = id;
            // bind Student to view
            return View(Student);
        }
    }
}