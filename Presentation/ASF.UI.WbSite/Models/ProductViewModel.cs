using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASF.Entities;
namespace ASF.UI.WbSite.Models
{
    public class ProductViewModel
    {
        public Dictionary<string, string> Idioma { get; set; }
        public IEnumerable<Product> Productos { get; set; }
    }
}