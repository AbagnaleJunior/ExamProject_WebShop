using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;


namespace RedPillCorp.WebShop.Application.IServices
{
    public interface IProductService
    {
        List<(int, string)> GetAllIdsAndNames();
        Product GetMostExpensiveProduct();
        Product GetById(Guid id);
        Product GetCheapestProduct();

        Product CreateProduct(Product product);
        Product DeleteProduct(Product product);
        Product UpdateProduct(Product returnProduct);
    }
}
