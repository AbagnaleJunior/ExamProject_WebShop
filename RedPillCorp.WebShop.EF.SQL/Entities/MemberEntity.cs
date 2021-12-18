﻿using System;
using System.Collections.Generic;

namespace RedPillCorp.WebShop.EF.SQL.Entities
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public Guid ModelId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
