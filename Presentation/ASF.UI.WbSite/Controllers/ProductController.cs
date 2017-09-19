using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Models;
using ASF.UI.WbSite.Services.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        private Dictionary<string, string> GetLang(string culture)
        {
            LanguageProcess process = new Process.LanguageProcess();
            var Language = DataCache.Instance.GetLang(culture);
            return Language;
        }
        public string GetAll()
        {
            var lang = GetLang("EN-US");
            Process.ProductProcess process = new Process.ProductProcess();
            List<Product> lista = process.GetAll();
            var model = new ProductViewModel();
            model.Productos = lista;
            model.Idioma = lang;
            return JsonConvert.SerializeObject(model, Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });

        }
    }
}