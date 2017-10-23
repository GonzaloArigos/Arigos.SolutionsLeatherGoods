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
using ASF.Services.Contracts.Requests;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Product")]
    public class ProductService : ApiController
    {
        [HttpGet]
        [Route("GetCartByIdClient")]
        public CartResponse GetCartByIdClient(int id)
        {
            try
            {
                var response = new CartResponse();
                response.Cart = ProductBusiness.GetCartByIdClient(id);
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

        [HttpPost]
        [Route("AgregarAlCarrito")]
        public void AgregarAlCarrito(AgregarAlCarritoRequest Request)
        {
            try
            {
                ProductBusiness.AgregarAlCarrito(Request.Item,Request.User);
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

        [HttpPost]
        [Route("ConfirmarCarrito")]
        public void ConfirmarCarrito(ConfirmarCarritoRequest request)
        {
            try
            {
                ProductBusiness.ConfirmarCarrito(request.User);
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
