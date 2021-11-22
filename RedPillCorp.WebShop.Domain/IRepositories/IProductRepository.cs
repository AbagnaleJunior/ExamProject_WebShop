using RedPillCorp.WebShop.Core.Models;
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
    }
}
