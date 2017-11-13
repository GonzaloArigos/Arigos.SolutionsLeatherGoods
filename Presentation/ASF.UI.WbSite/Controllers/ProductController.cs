using ASF.Entities;
using ASF.Services.Contracts.Responses;
using ASF.UI.Process;
using ASF.UI.WbSite.Models;
using ASF.UI.WbSite.Services.Cache;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

        public string GetAllNames()
        {
            Process.ProductProcess process = new Process.ProductProcess();
            return JsonConvert.SerializeObject(process.GetAllNames(), Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });

             

        }

        public string GetByName(string name)
        {
            Process.ProductProcess process = new Process.ProductProcess();
            return JsonConvert.SerializeObject(process.GetByName(name), Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });



        }
        public string GetAll(int skip)
        {
            int take = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Take"));
            var lang = GetLang("EN-US");
            Process.ProductProcess process = new Process.ProductProcess();
            ProductResponse lista = process.GetAll(skip,take);
            var model = new ProductViewModel();
            model.Productos = lista.Productos;
            model.Idioma = lang;
            model.Paginas = lista.Paginas;
            model.Take = take;
            return JsonConvert.SerializeObject(model, Formatting.None,
                                new JsonSerializerSettings()
                                {
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                });

        }

        public string GetName(string name)
        {
            return "AUTOCOMPLETE";
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
        public string VerFoto(HttpPostedFileBase file)
        {
            byte[] fileData = null;

            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }
            var Image = new Imagenes();
            Image.Archivo = fileData;
            Image.ContentType = file.ContentType;
            Image.Nombre = file.FileName;
            return JsonConvert.SerializeObject(Image, Formatting.None,
                   new JsonSerializerSettings()
                   {
                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                   });
        }


        [HttpPost]
        public void PublicarProducto(HttpPostedFileBase file, object product)
        {
            var p = (string[])product;
            Product _prod = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(p[0].ToString());
            byte[] fileData = null;

            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }

            Process.ProductProcess process = new Process.ProductProcess();

            _prod.Image = new Imagenes();
            _prod.Image.Archivo = fileData;
            _prod.Image.ContentType = file.ContentType;
            _prod.Image.Nombre = file.FileName;


            process.PublicarProducto(_prod);

     
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