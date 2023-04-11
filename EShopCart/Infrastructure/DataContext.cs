using EShopCart.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShopCart.Infrastructure
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }


        public DataContext(DbContextOptions<DataContext> options ) : base( options )
        {

        }
        public DbSet<EShopCart.Models.Promotions> Promotions { get; set; }
    }
}
