using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;
using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.Domain.Services;
using RedPillCorp.WebShop.EF.SQL;
using RedPillCorp.WebShop.EF.SQL.Repositories;
using RedPillCorp.WebShop.EF.SQL.Entities;
using Xunit.Abstractions;



namespace RedPillCorp.WebShop.Test.xUnit
{
    public class ProductServiceTest
    {
        private readonly WebshopDbContext _ctx;
        private readonly IProductService _service;


        public ProductServiceTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebshopDbContext>();
            optionsBuilder.UseSqlServer("Data Source = 10.176.111.31; Initial Catalog=HeilsbergFanClubTest; User ID=CSe20A_8; Password=CSe20A_8");
            _ctx = new WebshopDbContext(optionsBuilder.Options);

            IProductCategoryRepository repoProductCategories = new ProductCategoryRepository(_ctx);
            IProductRepository repoProducts = new ProductRepository(_ctx);

            _service = new ProductService(repoProductCategories, repoProducts);
        }

        [Fact]
        public void AllProductServiceTest()
        {
            _service.DatabaseSetup();
            
            // READ ALL GetAllIdsAndNames
            List<(Guid, string)> result = new List<(Guid, string)>();
            result.Add((Guid.Parse("1E469CF6-6156-407B-BC05-6E99C384B16C"), "Cult"));
            result.Add((Guid.Parse("CAC9BAF1-28BA-4E0F-9261-4DA81DFE6DDF"), "Monster"));
            result.Add((Guid.Parse("86828d6f-d533-4b38-a438-4c9ee4a9889b"), "PROSkate 1000"));
            result.Add((Guid.Parse("37A2BEB6-F6B7-4BA1-B099-1FB8925467CB"), "Redbull"));
            Assert.Equal(result, _service.Product_GetAllIdsAndNames());
            
            // READ GetById
            Guid id = Guid.Parse("CAC9BAF1-28BA-4E0F-9261-4DA81DFE6DDF");
            Product productServiceGetById = _service.Product_GetById(id);
            Assert.True(productServiceGetById.Id == id);

            // GetMostExpensiveProduct
            Product GetMostExpensiveProduct_Product = new Product()
            {
                Name = "PROSkate 1000",
                Price = 300,
            };
            Product GetMostExpensiveProduct_Service = _service.Product_GetMostExpensive();
            System.IO.File.WriteAllText(@"D:\test\GetMostExpensiveProduct.txt", GetMostExpensiveProduct_Service.Name.ToString());
            Assert.True(GetMostExpensiveProduct_Product.Price == GetMostExpensiveProduct_Service.Price);

            // GetCheapestProduct
            Product GetCheapestProduct_Product = new Product()
            {
                Name = "Cult",
                Price = 10,
            };
            Product GetCheapestProduct_Service = _service.Product_GetCheapest();
            Assert.True(GetCheapestProduct_Product.Price == GetCheapestProduct_Service.Price);

            // CreateProduct
            Product createProduct_productToBeCreated = new Product()
            {
                Name = "X-Ray",
                Price = 12,
                Category = new ProductCategory()
                {
                    Id = Guid.Parse("4F3F0942-FA85-407A-8FE4-913BF82502D3")
                }
            };
            Product createProductByService = _service.Product_Create(createProduct_productToBeCreated);
            Assert.Equal(createProduct_productToBeCreated, createProductByService);

            // UPDATE UpdateProduct
            Guid id_updateProduct = Guid.Parse("CAC9BAF1-28BA-4E0F-9261-4DA81DFE6DDF");
            Product updateProduct = _service.Product_GetById(id_updateProduct);
            updateProduct.Price = 9999;
            Product productUpdated = _service.Product_Update(updateProduct);
            Assert.True(updateProduct.Price == productUpdated.Price);

            // DELETE DeleteProduct()
            Guid id_deleteProduct = Guid.Parse("1E469CF6-6156-407B-BC05-6E99C384B16C");
            _service.Product_Delete(id);
            Product productDeleteFromService = _service.Product_GetById(id);
            Assert.True(productDeleteFromService == null);
        }
    }
}