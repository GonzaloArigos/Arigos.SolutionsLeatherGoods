using System;
using System.Collections.Generic;
using ASF.Entities;
using ASF.Services.Contracts.Responses;
using ASF.Services.Contracts.Requests;
using Newtonsoft.Json;

namespace ASF.UI.Process
{
    public class ProductProcess : ProcessComponent
    {
        public ProductResponse GetAll(int skip,int take)
        {

            var dic = new Dictionary<string, object>();
            dic.Add("skip", skip);
            dic.Add("take", take);

            var response = HttpGet<ProductResponse>("rest/Product/GetAll", dic, MediaType.Json);
            return response;
        }

        public CartResponse GetCartByIdClient(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("id", id);
            var response = HttpGet<CartResponse>("rest/Product/GetCartByIdClient", dic, MediaType.Json);

            return response;
        }

        public void AgregarAlCarrito(CartItem item, string user)
        {
            AgregarAlCarritoRequest Request = new AgregarAlCarritoRequest();
            Request.Item = item;
            Request.User = user;
            HttpPost<AgregarAlCarritoRequest>("rest/Product/AgregarAlCarrito", Request, MediaType.Json);
        }

        public List<object> GetAllNames()
        {
            var dic = new Dictionary<string, object>();
            var response = HttpGet<List<object>>("rest/Product/GetAllNames", dic, MediaType.Json);
            return response;
        }

        public void ConfirmarCarrito(string user)
        {
            ConfirmarCarritoRequest request = new ConfirmarCarritoRequest();
            request.User = user;
            HttpPost<ConfirmarCarritoRequest>("rest/Product/ConfirmarCarrito", request, MediaType.Json);
        }

        public List<Product> GetByName(string name)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("name",name);
            var response = HttpGet<GetByNameResponse>("rest/Product/GetByName", dic, MediaType.Json);
            return response.Productos;
        }

        public void PublicarProducto(Product producto)
        {
            PublicarProductoRequest request = new PublicarProductoRequest();
            request.Producto = producto;

            HttpPost<PublicarProductoRequest>("rest/Product/PublicarProducto", request, MediaType.Json);

        }
    }

}
