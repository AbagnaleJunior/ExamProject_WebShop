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

        #region CRUD
        List<Product> GetAll();
        Product CreateProduct(Product product);
        List<(Guid, string)> GetAllIdsAndNames();
        Product GetById(Guid id);
        Product UpdateProduct(Product product);
        void DeleteProduct(Guid id);
        #endregion

        #region Other
        Product GetCheapestProduct();
        Product GetMostExpensiveProduct();
        #endregion
    }
}
