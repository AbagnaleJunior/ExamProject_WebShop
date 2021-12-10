using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedPillCorp.WebShop.EF.SQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _ctx;


        public ProductRepository(ProductsDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<(int, string)> GetAllIdsAndNames()
        {
            var IdAndNamesList = _ctx.Products.Select(x => new Tuple<int, string>(x.Id, x.Name).ToValueTuple()).ToList();
            return IdAndNamesList;
        }

        public Product GetMostExpensiveProduct()
        {
            return _ctx.Products.Select(r => new Product()
            {
                Name = r.Name,
                Price = r.Price,
                Id = r.ModelId,

            }).OrderByDescending(r => r.Price).FirstOrDefault();
        }

        public Product GetById(Guid id)

        {
            return _ctx.Products.Select(r => new Product()
            {
                Name = r.Name,
                Price = r.Price,
                Id = r.ModelId

            }).FirstOrDefault(r => r.Id == id);
        }

        public Product GetCheapestProduct()
        {
            return _ctx.Products.Select(r => new Product()
            {
                Name = r.Name,
                Price = r.Price,
                Id = r.ModelId,

            }).OrderBy(r => r.Price).FirstOrDefault();
        }

        public Product CreateProduct(Product product)
        {
            var ProductEntity = _ctx.Products.Add(new ProductEntity
            {
                ModelId = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price
            }).Entity;
            _ctx.SaveChanges();

            return product;
        }

        public Product DeleteProduct(Product product)
        {
           
            ProductEntity entity = new ProductEntity { ModelId = product.Id };

          
            _ctx.Products.Remove(entity);
            _ctx.SaveChanges();
           
            return product;
        }

        public Product UpdateProduct(Product returnProduct)
        {
            ProductEntity newEntity = new ProductEntity
            {
                ModelId = returnProduct.Id,
                Name = returnProduct.Name,
                Price = returnProduct.Price
            };

            _ctx.Products.Update(newEntity);
            _ctx.SaveChanges();


            return returnProduct;
        }
    }
}
