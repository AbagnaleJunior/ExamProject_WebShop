using RedPillCorp.WebShop.Core.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
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
            var IdAndNamesList = _ctx.ProductsTest.Select(x => new Tuple<int, string>(x.Id, x.Name).ToValueTuple()).ToList();
            return IdAndNamesList;
        }

        public Product GetMostExpensiveProduct()
        {
            return _ctx.ProductsTest.Select(r => new Product()
            {
                Name = r.Name,
                Price = r.Price,
                Id = r.ModelId,

            }).OrderByDescending(r => r.Price).FirstOrDefault();
        }

        public Product GetById(Guid id)

        {
            return _ctx.ProductsTest.Select(r => new Product()
            {
                Name = r.Name,
                Price = r.Price,
                Id = r.ModelId

            }).FirstOrDefault(r => r.Id == id);
        }

        public Product GetCheapestProduct()
        {
            return _ctx.ProductsTest.Select(r => new Product()
            {
                Name = r.Name,
                Price = r.Price,
                Id = r.ModelId,

            }).OrderBy(r => r.Price).FirstOrDefault();
        }
    }
}
