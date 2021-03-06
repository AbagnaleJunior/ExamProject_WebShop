using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using System;
using System.Collections.Generic;

namespace RedPillCorp.WebShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCategoryRepository _repoProductCategories;
        private readonly IProductRepository _repoProducts;

        public ProductService(IProductCategoryRepository repoProductCategories, IProductRepository repoProducts)
        {
            _repoProductCategories = repoProductCategories;
            _repoProducts = repoProducts;
        }

        #region Common - Database setup

        public void DatabaseSetup()
        {
            // CLEANING DB
            _repoProducts.ResetDatabase();
            _repoProductCategories.ResetDatabase();
            

            // INIT DB
            _repoProductCategories.FeedDatabase();
            _repoProducts.FeedDatabase();

        }

        #endregion

        #region Product
        
        // CREATE
        public Product Product_Create(Product product)
        {
            return _repoProducts.CreateProduct(product);
        }
        // GET ALL
        public List<Product> Product_GetAll()
        {
            return _repoProducts.GetAll();
        }
        // READ BY ID
        public Product Product_GetById(Guid id)
        {
            return _repoProducts.GetById(id);
        }
        // READ ALL (IDs and Names)
        public List<(Guid, string)> Product_GetAllIdsAndNames()
        {
            return _repoProducts.GetAllIdsAndNames();
        }
        // UPDATE
        public Product Product_Update(Product product)
        {
            return _repoProducts.UpdateProduct(product);
        }
        // DELETE
        public void Product_Delete(Guid id)
        {
            _repoProducts.DeleteProduct(id);
        }

        // OTHER
        public Product Product_GetMostExpensive()
        {
            return _repoProducts.GetMostExpensiveProduct();
        }
        public Product Product_GetCheapest()
        {
            return _repoProducts.GetCheapestProduct();
        }
        #endregion

        #region ProductCategories

        // CREATE
        public ProductCategory ProductCategory_Create(ProductCategory productCategory)
        {
            return _repoProductCategories.CreateCategory(productCategory);
        }
        // READ ALL
        public List<ProductCategory> GetAllCategories()
        {
            return _repoProductCategories.GetAllCategories();
        }
        // READ
        public ProductCategory ProductCategory_GetById(Guid modelId)
        {
            return _repoProductCategories.GetProductCategoryById(modelId);
        }
        //UPDATE
        public ProductCategory ProductCategory_Update(ProductCategory productCategory)
        {
            return _repoProductCategories.UpdateCategory(productCategory);
        }
        // DELETE
        public void ProductCategory_Delete(Guid id)
        {
            _repoProductCategories.DeleteCategory(id);
        }
        #endregion

    }
}
