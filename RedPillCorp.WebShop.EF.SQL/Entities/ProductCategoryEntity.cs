using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class ProductCategoryEntity
    {
        //public int Id { get; set; }
        [Key]
        public Guid ModelId { get; set; }
        public string Name { get; set; }
        [ForeignKey("ModelId")]
        public ICollection<ProductEntity> Products {get; set;}
    }
}
