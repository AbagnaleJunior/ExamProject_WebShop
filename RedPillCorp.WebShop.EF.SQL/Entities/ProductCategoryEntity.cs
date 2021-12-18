using System;
using System.Collections.Generic;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }
        public Guid ModelId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductEntity> Products {get; set;}
    }
}
