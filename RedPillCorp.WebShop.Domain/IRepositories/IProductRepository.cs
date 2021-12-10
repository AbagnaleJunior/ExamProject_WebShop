using RedPillCorp.WebShop.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RedPillCorp.WebShop.Domain.IRepositories
{
    public interface IProductRepository
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
