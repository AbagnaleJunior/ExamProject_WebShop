using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedPillCorp.WebShop.EF.SQL.Entities;
using RedPillCorp.WebShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace RedPillCorp.WebShop.EF.SQL.Repositories
{

    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly WebshopDbContext _ctx;


        public ProductCategoryRepository(WebshopDbContext ctx)
        {
            _ctx = ctx;
        }

        #region Database - for test


        public void ResetDatabase()
        {
            List<ProductCategoryEntity> productCategories = _ctx.ProductCategories.ToList();
            foreach (var productCategory in productCategories)
            {
                _ctx.ProductCategories.Remove(productCategory);
            }
            _ctx.SaveChanges();
            _ctx.Database.ExecuteSqlRaw("DELETE FROM ProductCategories");
            _ctx.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('ProductCategories',RESEED, 1)");
        }

        public void FeedDatabase()
        {

            ProductCategoryEntity categoryEntity1 = new ProductCategoryEntity()
            {
                ModelId = Guid.Parse("4F3F0942-FA85-407A-8FE4-913BF82502D3"),
                Name = "Drikkevarer"
            };

            ProductCategoryEntity categoryEntity2 = new ProductCategoryEntity()
            {
                ModelId = Guid.Parse("B4BF8F09-8E77-44D8-AB51-31337D4CD46B"),
                Name = "Transport"
            };

            _ctx.ProductCategories.Add(categoryEntity1);
            _ctx.ProductCategories.Add(categoryEntity2);
            _ctx.SaveChanges();
        }
        #endregion

        #region CRUD
        // CREATE
        public ProductCategory CreateCategory(ProductCategory productCategory)
        {
            var productCategoryEntity = _ctx.ProductCategories.Add(new ProductCategoryEntity
            {
                ModelId = Guid.NewGuid(),
                Name = productCategory.Name

            }).Entity;

            _ctx.SaveChanges();
            
            productCategory.Id = productCategoryEntity.ModelId;
            return productCategory;
        }

        // REAL ALL
        public List<ProductCategory> GetAllCategories()
        {
            return _ctx.ProductCategories.Select(e => new ProductCategory()
            {
                Id = e.ModelId,
                Name = e.Name,
                Amount = e.Products.Count

            }).ToList();
        }

        // READ
        public ProductCategory GetProductCategoryById(Guid modelId)
        {
            return _ctx.ProductCategories.Select(r => new ProductCategory()
            {
                Id = r.ModelId,
                Name = r.Name,

            }).FirstOrDefault(r => r.Id == modelId);
        }

        // UPDATE
        public ProductCategory UpdateCategory(ProductCategory productCategory)
        {
            ProductCategoryEntity categoryEntity = _ctx.ProductCategories.First(e => e.ModelId == productCategory.Id);
            categoryEntity.Name = productCategory.Name;

            _ctx.ProductCategories.Update(categoryEntity);
            _ctx.SaveChanges();
            return productCategory;
        }

        // DELETE
        public void DeleteCategory(Guid id)
        {
            ProductCategoryEntity categoryEntity = _ctx.ProductCategories.FirstOrDefault(e => e.ModelId == id);

            _ctx.ProductCategories.Remove(categoryEntity);
            _ctx.SaveChanges();
        }
        #endregion
    }
}
