using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RedPillCorp.WebShop.EF.SQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebshopDbContext _ctx;


        public ProductRepository(WebshopDbContext ctx)
        {
            _ctx = ctx;
        }

        #region Database - For test

        public void ResetDatabase()
        {
            List<ProductEntity> products = _ctx.Products.ToList();
            foreach (var product in products)
            {
                _ctx.Products.Remove(product);
            }
            _ctx.SaveChanges();
            _ctx.Database.ExecuteSqlRaw("TRUNCATE TABLE Products");
            _ctx.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Products',RESEED, 1)");
        }

        public void FeedDatabase()
        {

            ProductEntity entity1 = new ProductEntity()
            {
                ModelId = Guid.Parse("37A2BEB6-F6B7-4BA1-B099-1FB8925467CB"),
                Name = "Redbull",
                Price = 20,
                Category = _ctx.ProductCategories.FirstOrDefault(x => x.ModelId == Guid.Parse("4F3F0942-FA85-407A-8FE4-913BF82502D3"))
            };

            ProductEntity entity2 = new ProductEntity()
            {
                ModelId = Guid.Parse("CAC9BAF1-28BA-4E0F-9261-4DA81DFE6DDF"),
                Name = "Monster",
                Price = 15,
                Category = _ctx.ProductCategories.FirstOrDefault(x => x.ModelId == Guid.Parse("4F3F0942-FA85-407A-8FE4-913BF82502D3"))
            };

            ProductEntity entity3 = new ProductEntity()
            {
                ModelId = Guid.Parse("1E469CF6-6156-407B-BC05-6E99C384B16C"),
                Name = "Cult",
                Price = 10,
                Category = _ctx.ProductCategories.FirstOrDefault(x => x.ModelId == Guid.Parse("4F3F0942-FA85-407A-8FE4-913BF82502D3"))
            };

            ProductEntity entity4 = new ProductEntity()
            {
                ModelId = Guid.Parse("86828d6f-d533-4b38-a438-4c9ee4a9889b"),
                Name = "PROSkate 1000",
                Price = 300,
                Category = _ctx.ProductCategories.FirstOrDefault(x => x.ModelId == Guid.Parse("B4BF8F09-8E77-44D8-AB51-31337D4CD46B"))
            };

            _ctx.Products.Add(entity1);
            _ctx.Products.Add(entity2);
            _ctx.Products.Add(entity3);
            _ctx.Products.Add(entity4);
            _ctx.SaveChanges();
        }
        #endregion

        #region CRUD
        // CREATE
        public Product CreateProduct(Product product)
        {
            Guid modelId = Guid.NewGuid();
            var productEntity = _ctx.Products.Add(new ProductEntity
            {
                ModelId = modelId,
                Name = product.Name,
                Price = product.Price,
                Category = _ctx.ProductCategories.First(e => e.ModelId == product.Category.Id)

            }).Entity;

            _ctx.SaveChanges();
            
            product.Id = modelId;
            product.Category = new ProductCategory()
            {
                Id = productEntity.Category.ModelId,
                Name = productEntity.Category.Name

            };
            return product;
        }

        public List<Product> GetAll()
        {
            return _ctx.Products.Include(e => e.Category).Select(e => new Product()
            {
                Id = e.ModelId,
                Name = e.Name,
                Price = e.Price,
                Category = new ProductCategory()

                {
                    Id = e.Category.ModelId,
                    Name = e.Category.Name
                }

            }).ToList();
        }

        // READ ALL
        public List<(Guid, string)> GetAllIdsAndNames()
        {
            var IdAndNamesList = _ctx.Products.OrderBy(p => p.Name).Select(x => new Tuple<Guid, string>(x.ModelId, x.Name).ToValueTuple()).ToList();
            return IdAndNamesList;
        }

        // READ
        public Product GetById(Guid id)

        {
            return _ctx.Products.Include(e => e.Category).Select(r => new Product()
            {
                Id = r.ModelId,
                Name = r.Name,
                Price = r.Price,
                Category = new ProductCategory()
                {
                    Id = r.Category.ModelId,
                    Name = r.Category.Name
                }

            }).FirstOrDefault(r => r.Id == id);
        }

        // UPDATE
        public Product UpdateProduct(Product product)
        {
            /*ProductEntity newEntity = new ProductEntity
            {
                ModelId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = _ctx.ProductCategories.First(e => e.ModelId == product.Category.Id)
            };*/

            ProductEntity entity = _ctx.Products.FirstOrDefault(x => x.ModelId == product.Id);

            if (entity != null)
            {
                entity.Name = product.Name;
                entity.Category = _ctx.ProductCategories.First(e => e.ModelId == product.Category.Id);
                entity.Price = product.Price;

                _ctx.Products.Update(entity);
                _ctx.SaveChanges();
                return product;
            }
            return null;
        }

        // DELETE
        public void DeleteProduct(Guid id)
        {
            ProductEntity entity = _ctx.Products.FirstOrDefault(e => e.ModelId == id);

            _ctx.Products.Remove(entity);
            _ctx.SaveChanges();
        }
        #endregion

        #region Other
        public Product GetCheapestProduct()
        {
            return _ctx.Products.Include(e => e.Category).Select(r => new Product()
            {
                Id = r.ModelId,
                Name = r.Name,
                Price = r.Price,
                Category = new ProductCategory()
                {
                    Id = r.Category.ModelId,
                    Name = r.Category.Name
                }

            }).OrderBy(r => r.Price).FirstOrDefault();
        }

        public Product GetMostExpensiveProduct()
        {
            return _ctx.Products.Include(e => e.Category).Select(r => new Product()
            {
                Id = r.ModelId,
                Name = r.Name,
                Price = r.Price,
                Category = new ProductCategory()
                {
                    Id = r.Category.ModelId,
                    Name = r.Category.Name
                }

            }).OrderByDescending(r => r.Price).FirstOrDefault();
        }
        #endregion
    }   
}

