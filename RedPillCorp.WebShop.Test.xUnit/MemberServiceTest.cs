using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.Domain.Services;
using RedPillCorp.WebShop.EF.SQL;
using RedPillCorp.WebShop.EF.SQL.Repositories;
using Xunit;
using System;
using System.Collections.Generic;

namespace RedPillCorp.WebShop.Test.xUnit
{
    [TestCaseOrderer("RedPillCorp.WebShop.Test.Help.AlphabeticalOrderer", "RedPillCorp.WebShop.Test.Help")]
    public class MemberServiceTest
    {
        private readonly IMemberService _service;
        private readonly WebshopDbContext _ctx;


        public MemberServiceTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebshopDbContext>();
            //optionsBuilder.UseSqlServer("Data Source = 10.176.111.31; Initial Catalog=HeilsbergFanClubTest; User ID=CSe20A_8; Password=CSe20A_8");
            optionsBuilder.UseSqlServer("Data Source=tcp:redpillcorp-webshop-webapidbserver.database.windows.net,1433;Initial Catalog=RedPillCorp.WebShop.WebAPI_db;User Id=CSe20A_8@redpillcorp-webshop-webapidbserver;Password=Frederik2021!Pass");
            _ctx = new WebshopDbContext(optionsBuilder.Options);

            IMemberRepository repo = new MemberRepository(_ctx);

            _service = new MemberService(repo);
        }

        [Fact]
        public void AllMemberServiceTest()
        {
            _service.DatabaseSetup();

            // READ BY ID
            Guid id = Guid.Parse("BA1D02D5-6516-4A05-9CBA-D2DBB5ED0C42");
            Member getById_Member = _service.ReadMemberById(id);
            
            Assert.True(getById_Member.Id == id);

            // READ BY EMAIL
            string readMemberByEmail_Member = "HALLO@HALLO.com";
            Member member = _service.ReadMemberByEmail(readMemberByEmail_Member);
            Assert.True(member.Email == readMemberByEmail_Member);

            // CREATE
            Guid id_CreateMember = Guid.NewGuid();
            Member createMember_Member = new Member()
            {
                Id = id,
                Name = "Peter",
                Email = "peter@protonmail.com",
                Phone = 20202020,
                Password = "",
                Salt = ""
            };
            Member memberService = _service.CreateMember(createMember_Member);
            Assert.True(memberService.Id == createMember_Member.Id);

            // UPDATE
            Guid id_update = Guid.Parse("D983AB5C-368C-4CB2-83A0-461D82F2BD93");
            Member updateMember = _service.ReadMemberById(id_update);
            updateMember.Name = "?";
            Member memberUpdated = _service.UpdateMember(updateMember);
            Assert.True(updateMember.Name == memberUpdated.Name);

            // DELETE
            Guid id_2 = Guid.Parse("E7DD9815-47CC-4048-B971-AAE793FF6DBA");
            _service.DeleteMember(id_2);
            Member readMemberById_member = _service.ReadMemberById(id_2);
            Assert.True(readMemberById_member == null);
        }
    }
}

        /*public MemberServiceTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebshopDbContext>();
            optionsBuilder.UseSqlServer("Data Source = 10.176.111.31; Initial Catalog=HeilsbergFanClubTest; User ID=CSe20A_8; Password=CSe20A_8");

            WebshopDbContext dbc = new WebshopDbContext(optionsBuilder.Options);
            IMemberRepository repo = new MemberRepository(dbc);

            _service = new MemberService(repo);
            *//*_service.DatabaseSetup();*//*
        }

        [Fact]

        public void Test1_Setup()
        {
            System.IO.File.WriteAllText(@"D:\test\Test1_Setup.txt", DateTime.Now.ToString("HH-mm-ss-fffff"));
            
            Assert.True(true);
        }

        // CREATE
        [Fact]
        public void Test2_CreateMember()
        {
            _service.DatabaseSetup();
            System.IO.File.WriteAllText(@"D:\test\Test2_CreateMember.txt", DateTime.Now.ToString("HH-mm-ss-fffff"));
            Guid id = Guid.NewGuid();
            
            Member member4 = new Member()
            {
                Id = id,
                Name = "Peter",
                Email = "peter@protonmail.com",
                Phone = 20202020,
                Password = "",
                Salt = ""
            };
            Member memberService = _service.CreateMember(member4);
            Assert.True(memberService.Id == member4.Id);
        }

        // READ
        [Fact]
        public void Test3_ReadMemberById()
        {
            
            Guid id = Guid.Parse("BA1D02D5-6516-4A05-9CBA-D2DBB5ED0C42");

            Member member = _service.ReadMemberById(id);
            System.IO.File.WriteAllText(@"D:\test\Test3_ReadMemberById.txt", member.Id.ToString());
            Assert.True(member.Id == id);
        }

        [Fact]
        public void Test4_ReadMemberByEmail()
        {
            System.IO.File.WriteAllText(@"D:\test\Test4_ReadMemberByEmail.txt", DateTime.Now.ToString("HH-mm-ss-fffff"));
            string email = "HALLO@HALLO.com";

            Member member = _service.ReadMemberByEmail(email);
            
            Assert.True(member.Email == email);
        }

        // UPDATE
        [Fact]
        public void Test5_UpdateMember()
        {
            System.IO.File.WriteAllText(@"D:\test\Test5_UpdateMember.txt", DateTime.Now.ToString("HH-mm-ss-fffff"));
            Guid id = Guid.Parse("D983AB5C-368C-4CB2-83A0-461D82F2BD93");
            Member member = _service.ReadMemberById(id);

            member.Name = "?";
            
            Member memberUpdated = _service.UpdateMember(member);
            
            Assert.True(member.Name == memberUpdated.Name);
        }

        // DELETE
        [Fact]
        public void Test6_DeleteMember()
        {
            System.IO.File.WriteAllText(@"D:\test\Test6_DeleteMember.txt", DateTime.Now.ToString("HH-mm-ss-fffff"));
            Guid id = Guid.Parse("E7DD9815-47CC-4048-B971-AAE793FF6DBA");
            
            _service.DeleteMember(id);

            Member member = _service.ReadMemberById(id);
            
            Assert.True(member == null);
        }*/
  