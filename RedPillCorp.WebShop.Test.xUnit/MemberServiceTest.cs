using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.Domain.Services;
using RedPillCorp.WebShop.EF.SQL;
using RedPillCorp.WebShop.EF.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RedPillCorp.WebShop.Test.xUnit
{
    public class MemberServiceTest
    {
        private readonly IMemberService _memberService;

        public MemberServiceTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MembersDbContext>();
            optionsBuilder.UseSqlServer("Data Source = 10.176.111.31; Initial Catalog=HeilsbergFanClubTest; User ID=CSe20A_8; Password=CSe20A_8");
            MembersDbContext dbContext = new MembersDbContext(optionsBuilder.Options);
            IMemberRepository repo = new MemberRepository(dbContext);
            
            _memberService = new MemberService(repo);
        }

        [Fact]
        public void Test1_CreateMember()
        {
            Member memberTest = new Member()
            {
                Name = "Michael",
                Email = "michael@hotmail.com",
                Phone = 88888888

            };
            Member memberService = _memberService.CreateMember(memberTest);
            Assert.True(memberTest.Name == memberService.Name && memberTest.Email == memberService.Email);
        }

        [Fact]
        public void Test2_DeleteMember()
        {
            Member memberTest = new Member()
            {
                Id = 5

            };
            Member memberService = _memberService.DeleteMember(memberTest);
        }
    }
}
