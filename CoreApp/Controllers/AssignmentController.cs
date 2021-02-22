using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Models;

namespace CoreApp.Controllers
{
    public class AssignmentController : Controller
    {
        private CoreContext context;

        public AssignmentController(CoreContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Assignment");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
           List<Assignment> Assignments;
            if (id == "All")
            {
                Assignments = context.Assignments
                    .OrderBy(p => p.AssignmentId).ToList();
            }
            else
            {
                Assignments = context.Assignments
                    .Where(a => a.AssignmentId.ToString() == id)
                    .OrderBy(a => a.AssignmentId).ToList();
            }
            
            // bind Assignments to view
            return View(Assignments);
        }

        public IActionResult Details(int id)
        {
            Assignment Assignment = context.Assignments.Find(id);

            // bind Assignment to view
            return View(Assignment);
        }
    }
}
