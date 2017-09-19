using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ASF.Services.Contracts;
using ASF.Services.Contracts.Responses;
using ASF.Business;
using System.Net.Http;
using System.Net;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Product")]
    public class ProductService : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public ProductResponse GetAll()
        {
            try
            {
                var response = new ProductResponse();
                response.Productos = ProductBusiness.GetAll();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
