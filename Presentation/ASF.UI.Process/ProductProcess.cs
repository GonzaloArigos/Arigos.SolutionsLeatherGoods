using System;
using System.Collections.Generic;
using ASF.Entities;
using ASF.Services.Contracts.Responses;

namespace ASF.UI.Process
{
    public class ProductProcess : ProcessComponent
    {
        public List<Product> GetAll()
        {
            var response = HttpGet<ProductResponse>("rest/Product/GetAll", new Dictionary<string, object>(), MediaType.Json);
            return response.Productos;
        }
    }
}