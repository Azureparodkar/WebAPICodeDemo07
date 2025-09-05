using Microsoft.EntityFrameworkCore;
using WebAPICodeDemo.Models.Domain;

namespace WebAPICodeDemo.Data
{
    public class NzwalksDBContext : DbContext
    {
        DbContext _Db;
        public NzwalksDBContext(DbContextOptions<NzwalksDBContext> dbContextOptions):base(dbContextOptions)
        {
         
        } 

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<walkz> Walkzes { get; set; }

    }
}
