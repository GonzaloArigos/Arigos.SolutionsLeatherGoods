using System;
using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business
{
    public static class ProductBusiness
    {
        public static List<Product> GetAll()
        {
            var DAC = new Data.ProductDAC();
            var nomap = DAC.GetAll();
            List<Product> retorno = new List<Product>();
            foreach(var item in nomap)
            {
                var x = new Product();
                Framework.Utilities.ReflectionUtilities.MapObjects(item, x);
                retorno.Add(x);
            }
           
            return retorno;
        }
    }
}