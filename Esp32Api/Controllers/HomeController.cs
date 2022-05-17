using Esp32Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esp32Api.NewFolder
{
    
    public class HomeController : Controller
    {
        //add dbcontext
        private readonly LocalContext ctx;
        public HomeController(LocalContext localContext)
        {
            ctx = localContext;
        }
        //register nwe data
        [HttpGet("api/data/list")]
        public List<TempData> Index()
        {
            return ctx.TempDatas.ToList();
        }

        [HttpGet("api/data/save/{value}")]
        public string Save(decimal value)
        {
            try
            {
                //delete all rows
                ctx.TempDatas.RemoveRange(ctx.TempDatas);
                ctx.SaveChanges();

                var data = ctx.TempDatas.Add(new TempData { Name = value, Id = Guid.NewGuid() });
                ctx.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        [HttpGet("api/data")]
        public dynamic Test()
        {
            return new { Id = "001", Data = "DATA" };
        }
    }
}
