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
        // CREATE
        ProductCategory ProductCategory_Create(ProductCategory productCategory);
        // READ BY ID
        ProductCategory ProductCategory_GetById(Guid modelId);
        // READ ALL
        List<ProductCategory> GetAllCategories();
        // UPDATE
        ProductCategory ProductCategory_Update(ProductCategory productCategory);
        // DELETE
        void ProductCategory_Delete(Guid id);
        #endregion

        #region Product

        // CREATE
        Product Product_Create(Product product);
        // READ ALL
        List<Product> Product_GetAll();
        // READ ALL (only extracting guid and name)
        List<(Guid, string)> Product_GetAllIdsAndNames();
        // READ
        Product Product_GetById(Guid id);
        // UPDATE
        Product Product_Update(Product product);
        // DELETE
        void Product_Delete(Guid id);

        // OTHER
        Product Product_GetMostExpensive();
        Product Product_GetCheapest();

        #endregion
    }
}
