using Microsoft.EntityFrameworkCore;

using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.Domain.Services;
using RedPillCorp.WebShop.EF.SQL;
using RedPillCorp.WebShop.EF.SQL.Repositories;
/*using RedPillCorp.WebShop.EF.SQLite;
using RedPillCorp.WebShop.EF.SQLite.Repositories;*/
using System;
using System.Collections.Generic;
using Xunit;

namespace RedPillCorp.WebShop.Test.xUnit
{
    public class ProductServiceTest
    {

        private readonly IProductService _service;

        public ProductServiceTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductsDbContext>();
            /*optionsBuilder.UseSqlite("Data Source=../../../ProductTest.db;");*/
            optionsBuilder.UseSqlServer("Data Source = 10.176.111.31; Initial Catalog=HeilsbergFanClubTest; User ID=CSe20A_8; Password=CSe20A_8");

            ProductsDbContext dbContext = new ProductsDbContext(optionsBuilder.Options);
            IProductRepository repo = new ProductRepository(dbContext);
            _service = new ProductService(repo);
        }

        [Fact]
        public void Test1_GetAllIdsAndNames()
        {
            List<(int, string)> result = new List<(int, string)>();
            result.Add((1, "Redbull"));
            result.Add((2, "Monster"));
            result.Add((3, "Cult"));
            
            Assert.Equal(result, _service.GetAllIdsAndNames());
        }

        [Fact]
        public void Test2_GetMostExpensiveProduct()
        {
            Product productTest = new Product()
            {
                Name = "Redbull",
                Price = 20,
            };
            Product productService = _service.GetMostExpensiveProduct();
            Assert.True(productTest.Name == productService.Name && productTest.Price == productService.Price);
        }

        [Fact]
        public void Test3_GetCheapestProduct()
        {
            Product productTest = new Product()
            {
                Name = "Cult",
                Price = 10,
            };
            Product productService = _service.GetCheapestProduct();
            Assert.True(productTest.Name == productService.Name && productTest.Price == productService.Price);
        }

        [Fact]
        public void Test4_GetById()
        {
            Guid id = Guid.Parse("6f8b1b06-cbf3-4130-8f83-578f9659c8cb");

            Product productTest = new Product()
            {
                Id = id,
            };
            Product productService = _service.GetById(id);
            Assert.True(productTest.Id == productService.Id);

        }

        [Fact]
        public void Test5_CreateProduct()
        {

            Product productTest = new Product()
            {
                Name = "X-Ray",
                Price = 12,

            };
            Product productService = _service.CreateProduct(productTest);
            Assert.True(productTest.Name == productService.Name && productTest.Price == productService.Price && productTest.Id == productService.Id);
        }

        [Fact]
        public void Test6_DeleteProduct()
        {
            Guid id = Guid.Parse("459b928b-7d90-4c33-8f49-bd556dc614a9");

            Product productTest = new Product()
            {
                Id = id

            };
            Product productService = _service.DeleteProduct(productTest);
            
        }

    }
}
