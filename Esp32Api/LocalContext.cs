using Esp32Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Esp32Api
{
    public class LocalContext : DbContext
    {
        public LocalContext(DbContextOptions<LocalContext> opts) : base(opts)
        {

        }
        public DbSet<TempData> TempDatas { get; set; }
    }
}
