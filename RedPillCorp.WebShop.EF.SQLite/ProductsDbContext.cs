using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.EF.SQLite.Entities;

namespace RedPillCorp.WebShop.EF.SQLite
{
    public class ProductsDbContext : DbContext
    {

        public ProductsDbContext(DbContextOptions<ProductsDbContext> opt) : base(opt)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

    }
}
