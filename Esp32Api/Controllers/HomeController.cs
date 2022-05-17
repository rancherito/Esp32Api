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
        [HttpGet("api/data/get")]
        public Response<TempData> Index()
        {
            try
            {
                var data = ctx.TempDatas.FirstOrDefault();
                return new Response<TempData> { Data = data };
            }
            catch (Exception e)
            {

                return new Response<TempData> { IsSuccess = false, Message = e.Message };
            }
        }

        [HttpGet("api/data/save/{value}")]
        public Response Save(decimal value)
        {
            try
            {
                //delete all rows
                ctx.TempDatas.RemoveRange(ctx.TempDatas);
                ctx.SaveChanges();

                var data = ctx.TempDatas.Add(new TempData { Name = value, Id = Guid.NewGuid() });
                ctx.SaveChanges();
                return new Response();
            }
            catch (Exception e)
            {

                return new Response { IsSuccess = false, Message = e.Message };
            }
        }
    }
}
