using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDBContext: DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> opt):base(opt)
        {
            
        }
    }
}
