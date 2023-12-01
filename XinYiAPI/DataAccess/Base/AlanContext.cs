
using Microsoft.EntityFrameworkCore;
using XinYiAPI.Eneities;
namespace XinYiAPI.DataAccess.Base
{
    public class AlanContext:DbContext
    {
        public AlanContext(DbContextOptions<AlanContext> options):base(options)
        {
        }
        public DbSet<Province> provinces { get; set; }
        public DbSet<City> citys { get; set; }
        public DbSet<District> districts { get; set; }
    }
}
