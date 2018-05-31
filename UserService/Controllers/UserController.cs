using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIUserServiec.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/user
        [HttpGet]
        public string Get()
        {
            var data = new
            {
                Id = 0,
                Name = "Tom",
                Age = 18
            };
            return JsonConvert.SerializeObject(data);
        }
    }
}
