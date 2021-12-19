using RedPillCorp.WebShop.Application.Models;
using System.Collections.Generic;
using System;

namespace RedPillCorp.WebShop.Domain.IRepositories
{
    public interface IProductRepository
    {
        #region Database - for test

        void ResetDatabase();
        void FeedDatabase();
        #endregion

        Product CreateProduct(Product product);
        List<Product> GetAll();
        Product GetById(Guid id);
        List<(Guid, string)> GetAllIdsAndNames();
        Product UpdateProduct(Product product);
        void DeleteProduct(Guid id);

        #region Other

        Product GetCheapestProduct();
        Product GetMostExpensiveProduct();
        #endregion
    }
}
