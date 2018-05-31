using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIProductService.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var data = new 
            {
                Id = 0,
                Name = "Vegetable",
                Price = 30
            };

            return JsonConvert.SerializeObject(data);
        }
    }
}