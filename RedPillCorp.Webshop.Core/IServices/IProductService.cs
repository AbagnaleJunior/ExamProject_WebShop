using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;


namespace RedPillCorp.WebShop.Application.IServices
{
    public interface IProductService
    {
        #region Database setup - for test

        public void DatabaseSetup();
        #endregion

        #region ProductCategories

        #region CRUD
        // CREATE
        ProductCategory ProductCategory_Create(ProductCategory productCategory);
        // READ
        ProductCategory ProductCategory_GetById(Guid modelId);
        // UPDATE
        ProductCategory ProductCategory_Update(ProductCategory productCategory);
        // DELETE
        void ProductCategory_Delete(Guid id);
        #endregion
        #endregion

        #region Product

        #region CRUD
        // CREATE
        Product Product_Create(Product product);
        List<Product> Product_GetAll();
        // READ ALL
        List<(Guid, string)> Product_GetAllIdsAndNames();
        // READ
        Product Product_GetById(Guid id);
        // UPDATE
        Product Product_Update(Product product);
        // DELETE
        void Product_Delete(Guid id);
        #endregion

        #region Other
        Product Product_GetMostExpensive();
        Product Product_GetCheapest();
        List<ProductCategory> GetAllCategories();

        #endregion
        #endregion
    }
}
