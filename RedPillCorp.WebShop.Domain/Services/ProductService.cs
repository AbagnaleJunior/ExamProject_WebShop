﻿using RedPillCorp.WebShop.Core.IServices;
using RedPillCorp.WebShop.Core.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPillCorp.WebShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public List<(int, string)> GetAllIdsAndNames()
        {
            return _repo.GetAllIdsAndNames();
        }

        public Product GetMostExpensiveProduct()
        {
            return _repo.GetMostExpensiveProduct();
        }

        public Product GetById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}