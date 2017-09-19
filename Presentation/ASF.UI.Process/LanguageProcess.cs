using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class LanguageProcess : ProcessComponent
    {
        public Dictionary<string, string> GetLang(string culture)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("culture", culture);
            var response = HttpGet<Services.Contracts.Responses.LanguageResponse>("rest/Language/GetLang", parameters, MediaType.Json);
            return response.Result;
        }
    }
}