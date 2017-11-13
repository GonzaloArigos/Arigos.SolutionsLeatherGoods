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
        public ProductResponse GetAll(int take, int skip)
        {
            try
            {
                var response = new ProductResponse();
                response.Productos = ProductBusiness.GetAll(take, skip);
                response.Paginas = ProductBusiness.CountProductos(take) + 1;
                if (skip > 0 && take> 0)
                {
                    response.PaginaActual = (int)(skip / take) +1;
                }
                else
                {
                    response.PaginaActual = 1;
                }

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
        [Route("GetAllNames")]
        public List<object> GetAllNames()
        {
            try
            {
                
                return ProductBusiness.GetAllNames();
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
        [Route("GetByName")]
        public GetByNameResponse GetByName(string name)
        {
            try
            {
               var lista = ProductBusiness.GetByName(name);
                var retorno = new GetByNameResponse();
                retorno.Productos = lista;
                return retorno;
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
                ProductBusiness.AgregarAlCarrito(Request.Item, Request.User);
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
        [Route("PublicarProducto")]
        public void PublicarProducto(PublicarProductoRequest request)
        {
            try
            {

                ProductBusiness.PublicarProducto(request.Producto);


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
