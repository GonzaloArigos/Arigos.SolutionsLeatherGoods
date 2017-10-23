using System;
using System.Collections.Generic;
using ASF.Entities;
using ASF.Services.Contracts.Responses;
using ASF.Services.Contracts.Requests;

namespace ASF.UI.Process
{
    public class ProductProcess : ProcessComponent
    {
        public List<Product> GetAll()
        {
            var response = HttpGet<ProductResponse>("rest/Product/GetAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Productos;
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

        public void ConfirmarCarrito(string user)
        {
            ConfirmarCarritoRequest request = new ConfirmarCarritoRequest();
            request.User = user;
            HttpPost<ConfirmarCarritoRequest>("rest/Product/ConfirmarCarrito", request, MediaType.Json);
        }
    }

}
