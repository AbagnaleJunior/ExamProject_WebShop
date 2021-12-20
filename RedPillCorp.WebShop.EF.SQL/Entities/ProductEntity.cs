using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class ProductEntity
    {
        [Key]
        public Guid ModelId { get; set; }
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [ForeignKey("CategoryId")]
        public ProductCategoryEntity Category { get; set; }
    }
}
