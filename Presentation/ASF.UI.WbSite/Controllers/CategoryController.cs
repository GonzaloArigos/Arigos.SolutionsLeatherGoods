using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            var lista = process.SelectList();
            return View(lista);
        }

        public ActionResult Find(int id)
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            var lista = process.FindById(id);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            process.Create(cat);
            return RedirectToAction("Index");
        }

        public ActionResult FindByEdit(int id)
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            var lista = process.FindById(id);
            return View(lista);
        }

        [HttpPost]
        public ActionResult FindByEdit(Category objeto)
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            process.FindById(objeto);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            process.Remove(id);
           return RedirectToAction("Index");
        }

    }
}