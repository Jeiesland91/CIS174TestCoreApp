using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CoreApp.Models;

namespace CoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LevelController : Controller
    {
        private CoreContext context;

        public LevelController(CoreContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/levels/{id?}")]
        public IActionResult List()
        {
            var levels = context.Levels
                .OrderBy(c => c.LevelId).ToList();
            return View(levels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Level());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var level = context.Levels.Find(id);
            return View("AddUpdate", level);
        }

        [HttpPost]
        public IActionResult Update(Level level)
        {
            if (ModelState.IsValid)
            {
                if (level.LevelId == 0)
                {
                    context.Levels.Add(level);
                }
                else
                {
                    context.Levels.Update(level);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Level level = context.Levels.Find(id);
            return View(level);
        }


        [HttpPost]
        public IActionResult Delete(Level level)
        {
            context.Levels.Remove(level);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}