using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPillCorp.WebShop.EF.SQL
{
    public class MembersDbContext : DbContext
    {
        public MembersDbContext(DbContextOptions<MembersDbContext> opt) : base(opt)
        {
        }

        public DbSet<MemberEntity> Members { get; set; }
    }
}
