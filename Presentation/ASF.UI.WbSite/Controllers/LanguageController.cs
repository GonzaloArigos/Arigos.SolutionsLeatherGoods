using ASF.UI.Process;
using ASF.UI.WbSite.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }

        public Dictionary<string, string> GetNewLang(string culture)
        {
            LanguageProcess process = new Process.LanguageProcess();
            var Language = DataCache.Instance.GetNewLang(culture.ToUpper());
            return Language;
        }
    }
}