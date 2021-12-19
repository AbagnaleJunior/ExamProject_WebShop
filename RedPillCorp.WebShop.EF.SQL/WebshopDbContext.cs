using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPillCorp.WebShop.EF.SQL
{
    public class WebshopDbContext : DbContext
    {
        public WebshopDbContext(DbContextOptions<WebshopDbContext> opt) : base(opt)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategoryEntity>()
            .HasMany(c => c.Products)
            .WithOne(e => e.Category);

           /* modelBuilder.Entity<TagsEntity>()
            .HasMany(c => c.Products)
            .WithMany(e => e.Tags);*/

        }
    }
}
