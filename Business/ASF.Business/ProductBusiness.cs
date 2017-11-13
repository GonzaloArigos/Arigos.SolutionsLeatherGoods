using System;
using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business
{
    public static class ProductBusiness
    {
        public static List<Product> GetAll(int take,int skip)
        {
            var DAC = new Data.ProductDAC();
            var nomap = DAC.GetAll(take, skip);
            List<Product> retorno = new List<Product>();
            foreach (var item in nomap)
            {
                var x = new Product();
                x.Image = new Imagenes();
                Framework.Utilities.ReflectionUtilities.MapObjects(item, x);
                Framework.Utilities.ReflectionUtilities.MapObjects(item.Imagenes, x.Image);
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

        public static int CountProductos(int take)
        {
            var DAC = new Data.ProductDAC();
            int cantidad = DAC.CountProductos(take);
            return (int)(cantidad / take); 
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

        public static void PublicarProducto(Product producto)
        {
            var DAC = new Data.ProductDAC();

            DAC.PublicarProducto(producto);

        }

        public static List<object> GetAllNames()
        {
            var DAC = new Data.ProductDAC();

           List<Data.Product> productos = DAC.GetAllNames();


            var retorno = new List<object>();
            foreach (var item in productos)
            {
                var nombre = new
                {
                    name = item.Title,
                    Image = item.Imagenes.Archivo,
                    ContentType = item.Imagenes.ContentType
                };
                retorno.Add(nombre);
            }
            return retorno;
        }

        public static List<Product> GetByName(string name)
        {
            var DAC = new Data.ProductDAC();

            var nomap = DAC.GetByName(name);
            List<Product> retorno = new List<Product>();
            foreach (var item in nomap)
            {
                var x = new Product();
                x.Image = new Imagenes();
                Framework.Utilities.ReflectionUtilities.MapObjects(item, x);
                Framework.Utilities.ReflectionUtilities.MapObjects(item.Imagenes, x.Image);
                retorno.Add(x);
            }

            return retorno;
        }
    }
}