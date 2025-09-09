using Ecommerse.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse.DbContect
{
    public class EcommesdbContext :IdentityDbContext<ApplecationUser>
    {

        public  DbSet<Cls_Product > products {  get; set; } 

        public  DbSet<Cls_Catagoury> catagouries { get; set; }


        public EcommesdbContext(DbContextOptions<EcommesdbContext> options)
            : base(options)
        {

        }


    }
}
