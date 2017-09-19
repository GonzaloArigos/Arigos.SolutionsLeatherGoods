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
    [RoutePrefix("rest/Language")]
    public class LanguageService : ApiController
    {
        [HttpGet]
        [Route("GetLang")]
        public LanguageResponse GetLang(string culture)
        {
            try
            {
                var response = new LanguageResponse();
                response.Result = LangBusiness.GetLang(culture);
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
