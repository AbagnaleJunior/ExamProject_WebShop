using RedPillCorp.WebShop.Core.Models;
using System;
using System.Collections.Generic;


namespace RedPillCorp.WebShop.Core.IServices
{
    public interface IProductService
    {
        List<(int, string)> GetAllIdsAndNames();

        Product GetMostExpensiveProduct();

        Product GetById(Guid id);
    }
}
