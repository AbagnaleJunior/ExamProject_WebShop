using System;
using System.Collections.Generic;
using RedPillCorp.WebShop.Application.Models;

namespace RedPillCorp.WebShop.Domain.IRepositories
{
    public interface IProductCategoryRepository
    {
        #region Database - for test

        void ResetDatabase();
        void FeedDatabase();
        #endregion

        ProductCategory CreateCategory(ProductCategory productCategory);
        List<ProductCategory> GetAllCategories();
        ProductCategory GetProductCategoryById(Guid modelId);
        ProductCategory UpdateCategory(ProductCategory productCategory);
        void DeleteCategory(Guid id);
       
    }
}
