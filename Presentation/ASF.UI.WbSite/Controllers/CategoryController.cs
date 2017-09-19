using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.WbSite.Services.Cache;
using ASF.UI.Process;
using ASF.UI.WbSite.Models;
using Newtonsoft.Json;

namespace ASF.UI.WbSite.Controllers
{
    public class CategoryController : Controller
    {

        private Dictionary<string,string> GetLang(string culture)
        {
            LanguageProcess process = new Process.LanguageProcess();
            var Language = DataCache.Instance.GetLang(culture);
            return Language;           
        }
        
        // GET: Category
        public object Index()
        {
            var lang = GetLang("EN-US");

            var lista = DataCache.Instance.CategoryAll();

            var retorno = new CategoryViewModel
            {
                Categorias = lista,
                Idioma = lang
            };

            return JsonConvert.SerializeObject(retorno, Formatting.None,
                     new JsonSerializerSettings()
                     {
                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                     });

        }

        public ActionResult Find(int id)
        {
            var lista = DataCache.Instance.CategoryOne(id);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(object category)
        {
            Category Categoria = Newtonsoft.Json.JsonConvert.DeserializeObject<Category>(category.ToString());
            Process.CategoryProcess process = new Process.CategoryProcess();
            process.Create(Categoria);
            return RedirectToAction("Index");
        }

        public ActionResult FindByEdit(int id)
        {
            Process.CategoryProcess process = new Process.CategoryProcess();
            var lista = process.FindById(id);
            return View(lista);
        }

        [HttpPost]
        public void FindByEdit(object category)
        {
            Category Categoria = Newtonsoft.Json.JsonConvert.DeserializeObject<Category>(category.ToString());
            Process.CategoryProcess process = new Process.CategoryProcess();
            process.FindById(Categoria);
           
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