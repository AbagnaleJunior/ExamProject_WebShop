﻿using System;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class ProductEntity
    {
        public Guid ModelId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductCategoryEntity Category { get; set; }
    }
}
