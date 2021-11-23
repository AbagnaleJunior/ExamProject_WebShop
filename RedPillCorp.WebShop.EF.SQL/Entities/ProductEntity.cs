using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class ProductEntity
    {
    public Guid ModelId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    }
}
