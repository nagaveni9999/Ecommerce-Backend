using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping11.Models;

namespace Onlineshopping11.Models
{
    public class ProductDBContext
    {
        public class ProductDbContext : IdentityDbContext<ApplicationUsers>
        {
            public ProductDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Garments> Products { get; set; }
            public DbSet<OnlineShopping11.Models.Cart> Cart { get; set; }
        }
    }
}
