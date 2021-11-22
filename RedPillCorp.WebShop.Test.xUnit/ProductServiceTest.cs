using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.Core.IServices;
using RedPillCorp.WebShop.Core.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.Domain.Services;
using RedPillCorp.WebShop.EF.SQLite;
using RedPillCorp.WebShop.EF.SQLite.Repositories;
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
            optionsBuilder.UseSqlite("Data Source=../../../ProductTest.db;");

            ProductsDbContext dbContext = new ProductsDbContext(optionsBuilder.Options);
            IProductRepository repo = new ProductRepository(dbContext);
            _service = new ProductService(repo);
        }

        [Fact]
        public void GetAllIdsAndNames()
        {
            List<(int, string)> result = new List<(int, string)>();
            result.Add((1, "Monster"));
            result.Add((2, "RedBull"));
            result.Add((3, "Cult"));
            
            Assert.Equal(result, _service.GetAllIdsAndNames());
        }

        [Fact]
        public void GetMostExpensiveProduct()
        {
            Product productTest = new Product()
            {
                Name = "Monster",
                Price = 20,
            };
            Product productService = _service.GetMostExpensiveProduct();
            Assert.True(productTest.Name == productService.Name && productTest.Price == productService.Price);
        }

        [Fact]
        public void GetById()
        {
            Guid id = Guid.Parse("6f8b1b06-cbf3-4130-8f83-578f9659c8cb");

            Product productTest = new Product()
            {
                Id = id,
            };
            Product productService = _service.GetById(id);

            Assert.True(productTest.Id == productService.Id);
        }
    }
}
