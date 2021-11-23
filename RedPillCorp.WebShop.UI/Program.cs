using Microsoft.Extensions.DependencyInjection;
using RedPillCorp.WebShop.Core.IServices;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.Domain.Services;
/*using RedPillCorp.WebShop.EF.SQLite;
using RedPillCorp.WebShop.EF.SQLite.Repositories;*/
using System;
using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.EF.SQL.Repositories;
using RedPillCorp.WebShop.EF.SQL;

namespace RedPillCorp.WebShop.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ProductsDbContext>(options => options.UseSqlServer("Data Source = 10.176.111.31; Initial Catalog=HeilsbergFanClubTest; User ID=CSe20A_8; Password=CSe20A_8"));
            /*serviceCollection.AddDbContext<ProductsDbContext>(options => options.UseSqlite("Data Source =../../../../RedPillCorp.WebShop.Test.xUnit/ProductTest.db"));*/

            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IProductService, ProductService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var productService = serviceProvider.GetRequiredService<IProductService>();

            var menu = new Menu(productService);
            menu.Start();
        }
    }
}

