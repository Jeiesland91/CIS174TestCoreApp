using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CoreApp.Models;

namespace CoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssignmentController : Controller
    {

        private CoreContext context;

        public AssignmentController(CoreContext ctx)
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
            List<Assignment> Assignments;
            //if (id == "All")
            //{
                Assignments = context.Assignments
                    .OrderBy(a => a.AssignmentId).ToList();
            //}
            //else
            //{
            //    Assignments = context.Assignments
            //        .Where(a => a.AssignmentId.ToString() == id)
            //        .OrderBy(a => a.AssignmentId).ToList();
            //}

            // bind Assignments to view
            return View(Assignments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // create new Student object
            Assignment Assignment = new Assignment();                // create Assignment object

            // use ViewBag to pass action and level data to view
            ViewBag.Action = "Add";
 

            // bind Student to AddUpdate view
            return View("AddUpdate", Assignment);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Student object for specified primary key
            Assignment Assignment = context.Assignments
                .FirstOrDefault(a => a.AssignmentId == id);

            // use ViewBag to pass action and level data to view
            ViewBag.Action = "Update";

            // bind Assignment to AddUpdate view
            return View("AddUpdate", Assignment);
        }

        [HttpPost]
        public IActionResult Update(Assignment Assignment)
        {
            if (ModelState.IsValid)
            {
                if (Assignment.AssignmentId == 0)           // new Assignment
                {
                    context.Assignments.Add(Assignment);
                }
                else                                  // existing Assignment
                {
                    context.Assignments.Update(Assignment);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate", Assignment);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Assignment Assignment = context.Assignments
                .FirstOrDefault(a => a.AssignmentId == id);
            return View(Assignment);
        }

        [HttpPost]
        public IActionResult Delete(Assignment Assignment)
        {
            context.Assignments.Remove(Assignment);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
