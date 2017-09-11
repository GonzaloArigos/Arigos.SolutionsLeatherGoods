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
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Category FindById(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id",id);            

            var response = HttpGet<FindResponse>("rest/Category/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Create(Category cat)
        {
            HttpPost<Category>("rest/Category/Add", cat, MediaType.Json);
        }

        public void FindById(Category objeto)
        {         
            HttpPost<Category>("rest/Category/Edit", objeto, MediaType.Json);
        }

        public void Remove(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);

           HttpGet<FindResponse>("rest/Category/Remove", parameters, MediaType.Json);
        }
    }
}