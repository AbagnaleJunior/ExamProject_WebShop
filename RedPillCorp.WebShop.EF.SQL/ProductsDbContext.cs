using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPillCorp.WebShop.EF.SQL
{
    public class ProductsDbContext : DbContext
    {

        public ProductsDbContext(DbContextOptions<ProductsDbContext> opt) : base(opt)
        {
        }

        public DbSet<ProductEntity> ProductsTest { get; set; }

    }
   
}
