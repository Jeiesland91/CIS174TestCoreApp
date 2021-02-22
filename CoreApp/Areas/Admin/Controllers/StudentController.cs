using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreApp.Models;

namespace CoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private CoreContext context;

        public StudentController(CoreContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List()
        {
            List<Student> Students;
            
                Students = context.Students
                    .OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName).ToList();

                // bind Students to view
            return View(Students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // create new Student object
            Student Student = new Student();              // create Student object

            // use ViewBag to pass action and level data to view
            ViewBag.Action = "Add";

            // bind Student to AddUpdate view
            return View("AddUpdate", Student);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Student object for specified primary key
            Student Student = context.Students
                .FirstOrDefault(p => p.StudentId == id);

            // use ViewBag to pass action and level data to view
            ViewBag.Action = "Update";
 
            // bind Student to AddUpdate view
            return View("AddUpdate", Student);
        }

        [HttpPost]
        public IActionResult Update(Student Student)
        {
            if (ModelState.IsValid)
            {
                if (Student.StudentId == 0)           // new Student
                {
                    context.Students.Add(Student);
                }
                else                                  // existing Student
                {
                    context.Students.Update(Student);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", Student);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student Student = context.Students
                .FirstOrDefault(s => s.StudentId == id);
            return View(Student);
        }

        [HttpPost]
        public IActionResult Delete(Student Student)
        {
            context.Students.Remove(Student);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}