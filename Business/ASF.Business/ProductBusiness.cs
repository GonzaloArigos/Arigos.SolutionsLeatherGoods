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
            foreach (var item in nomap)
            {
                var x = new Product();
                Framework.Utilities.ReflectionUtilities.MapObjects(item, x);
                retorno.Add(x);
            }

            return retorno;
        }

        public static Cart GetCartByIdClient(int id)
        {
            var DAC = new Data.ProductDAC();
            var nomap = DAC.GetCartByIdClient(id);
            Cart retorno = new Cart();

            Framework.Utilities.ReflectionUtilities.MapObjects(nomap, retorno);

            retorno.CartItem = new List<CartItem>();

            foreach (var item in nomap.CartItem)
            {
                var x = new CartItem();
                Framework.Utilities.ReflectionUtilities.MapObjects(item, x);
                x.Product = new Product();
                Framework.Utilities.ReflectionUtilities.MapObjects(item.Product, x.Product);
                retorno.CartItem.Add(x);
            }

            return retorno;
        }

        public static void AgregarAlCarrito(CartItem item, string user)
        {
            var DAC = new Data.ProductDAC();
            DAC.AgregarAlCarrito(item, user);
        }

        public static void ConfirmarCarrito(string user)
        {
            var DAC = new Data.ProductDAC();
            DAC.ConfirmarCarrito(user);
        }
    }
}