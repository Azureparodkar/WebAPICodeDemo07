using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPICodeDemo.Data
{
    public class NZwalksAuthDBcontext : IdentityDbContext
    {
        public NZwalksAuthDBcontext(DbContextOptions<NZwalksAuthDBcontext>  dbContextOptions) :base(dbContextOptions) 
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var readerroleId = "c2791820-0704-429c-a4f2-d57bf9533ffe";
            var writerId = "bc27bcd1-286a-4d21-b2cb-9c8204489725";

            var roles = new List<IdentityRole>()
            {

                new IdentityRole
                {
                    Id= readerroleId,
                    Name="Reader",
                    NormalizedName= "Reader".ToUpper(),
                    ConcurrencyStamp=  readerroleId,
                },

                new IdentityRole
                {
                    Id=  writerId,
                    Name = "Writer",
                    NormalizedName= "Writer".ToUpper(),
                    ConcurrencyStamp = writerId,
                }

            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
