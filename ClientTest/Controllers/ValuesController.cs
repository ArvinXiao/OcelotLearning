using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;

namespace ClientTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// 获取User、Product信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            //User
            string userApi = "user";
            string user = SendRequest(userApi);

            //Product
            string productApi = "product";
            string product = SendRequest(productApi);

            return $"User: {user}, Product:{product}";
        }

        private string SendRequest(string api)
        {
            string result;
            string baseHost = "http://localhost:5000/api";
            var request = WebRequest.Create(new Uri($"{baseHost}/{api}"));
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            
            return result;
        }
    }
}
