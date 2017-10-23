using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Models;
using ASF.UI.WbSite.Services.Cache;
using Microsoft.AspNet.Identity.Owin;
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
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
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

        public string GetCartByIdClient(int id)
        {
            Process.ProductProcess process = new Process.ProductProcess();
            Cart Carrito = process.GetCartByIdClient(1).Cart;
            return JsonConvert.SerializeObject(Carrito, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
        }

        [HttpPost]
        public void AgregarAlCarrito(object item)
        {
            Process.ProductProcess process = new Process.ProductProcess();
            CartItem Item = Newtonsoft.Json.JsonConvert.DeserializeObject<CartItem>(item.ToString());
            var user = User.Identity.Name;
            process.AgregarAlCarrito(Item,user);
        }

        [HttpPost]
        public void ConfirmarCarrito()
        {
            Process.ProductProcess process = new Process.ProductProcess();
            var user = User.Identity.Name;
            process.ConfirmarCarrito(user);
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
    }
}