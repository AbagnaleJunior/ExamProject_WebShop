using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPillCorp.WebShop.EF.SQL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MembersDbContext _ctx;

        public MemberRepository(MembersDbContext ctx)
        {
            _ctx = ctx;
        }

        public Member CreateMember(Member newMember)
        {
            var newMemberEntity = _ctx.Members.Add(new Entities.MemberEntity
            {
                Id = newMember.Id,
                Name = newMember.Name,
                Email = newMember.Email,
                Phone = newMember.Phone

            }).Entity;
            _ctx.SaveChanges();

            return newMember;
        }

        public Member DeleteMember(Member member)
        {
            MemberEntity entity = new() { Id = member.Id };

            _ctx.Members.Remove(entity);
            _ctx.SaveChanges();

            return member;
        }
    }
}
