using System;

namespace RedPillCorp.WebShop.Application.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductCategory Category { get; set; }
    }
}
