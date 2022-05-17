using Microsoft.AspNetCore.Mvc;

namespace Esp32Api.NewFolder
{
    public class HomeController : Controller
    {
        [HttpGet("api/data")]
        public dynamic Test()
        {
            return new { Id = "001", Data = "DATA" };
        }
    }
}
