using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class MemberEntity
    {
        //public int Id { get; set; }
        [Key]
        public Guid ModelId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
