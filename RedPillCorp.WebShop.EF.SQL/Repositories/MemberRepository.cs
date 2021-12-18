using Microsoft.EntityFrameworkCore;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using RedPillCorp.WebShop.EF.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RedPillCorp.WebShop.EF.SQL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly WebshopDbContext _ctx;

        public MemberRepository(WebshopDbContext ctx)
        {
            _ctx = ctx;
        }

        #region Database - for test

        public void ResetDatabase()
        {
            List<MemberEntity> members = _ctx.Members.ToList();
            foreach (var member in members)
            {
                _ctx.Members.Remove(member);
            }

            _ctx.SaveChanges();
            _ctx.Database.ExecuteSqlRaw("TRUNCATE TABLE Members");
            _ctx.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Members',RESEED, 1)");
        }

        public void FeedDatabase()
        {

            MemberEntity member1 = new MemberEntity()
            {
                ModelId = Guid.Parse("BA1D02D5-6516-4A05-9CBA-D2DBB5ED0C42"),
                Name = "Frederik",
                Email = "Frederik@outlook.com",
                Phone = 44444444,
                Password = "",
                Salt = ""
            };

            MemberEntity member2 = new MemberEntity()
            {
                ModelId = Guid.Parse("D983AB5C-368C-4CB2-83A0-461D82F2BD93"),
                Name = "Michael",
                Email = "michael@hotmail.com",
                Phone = 88888888,
                Password = "",
                Salt = ""
            };

            MemberEntity member3 = new MemberEntity()
            {
                ModelId = Guid.Parse("E7DD9815-47CC-4048-B971-AAE793FF6DBA"),
                Name = "TEEEEEEST",
                Email = "test@protonmail.com",
                Phone = 99999999,
                Password = "",
                Salt = ""
            };

            MemberEntity member4 = new MemberEntity()
            {
                ModelId = Guid.Parse("29DFD4CC-0FDB-4CC3-866F-AA2A98C94FA5"),
                Name = "BAMSE",
                Email = "HALLO@HALLO.com",
                Phone = 000111000,
                Password = "",
                Salt = ""
            };

            _ctx.Members.Add(member1);
            _ctx.Members.Add(member2);
            _ctx.Members.Add(member3);
            _ctx.Members.Add(member4);
            _ctx.SaveChanges();
        }
        #endregion

        #region CRUD
        // CREATE
        public Member CreateMember(Member member)
        {
            Guid modelId = Guid.NewGuid();
            var MemberEntity = _ctx.Members.Add(new MemberEntity
            {
                ModelId = modelId,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Password = member.Password,
                Salt = member.Salt

            }).Entity;

            _ctx.SaveChanges();
            member.Id = modelId;
            return member;
        }

        // READ
        public Member ReadMemberById(Guid id)
        {
            return _ctx.Members.Select(e => new Member()
            {
                Id = e.ModelId,
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Password = e.Password,
                Salt = e.Salt

            }).FirstOrDefault(e => e.Id == id);
        }

        // READ ALL
        public List<Member> ReadAll()
        {
            return _ctx.Members.Select(m => new Member()
            {
                Id = m.ModelId,
                Name = m.Name,
                Email = m.Email,
                Phone = m.Phone,
                Password = m.Password,
                Salt = m.Salt

            }).ToList();
        }

        // READ
        public Member ReadMemberByEmail(string email)
        {
            StringBuilder sb = new StringBuilder();

            Member member = null;

            sb.Append(email);
            sb.Append(",");

            foreach (var m in _ctx.Members.ToList())
            {
                sb.Append(m.Email);
                sb.Append(",");

                if (m.Email.ToLower() == email.ToLower())
                {
                    member = new Member()
                    {
                        Id = m.ModelId,
                        Name = m.Name,
                        Email = m.Email,
                        Phone = m.Phone,
                        Password = m.Password,
                        Salt = m.Salt
                    };

                    break;
                }
            }

            System.IO.File.WriteAllText(@"D:\test\member.txt", sb.ToString());

            return member;
        }

        // UPDATE
        public Member UpdateMember(Member member)
        {
            MemberEntity entity = _ctx.Members.FirstOrDefault(x => x.ModelId == member.Id);

            if (entity != null)
            {
                entity.Name = member.Name;
                entity.Phone = member.Phone;
                entity.Email = member.Email;
                entity.Password = member.Password;
                entity.Salt = member.Salt;

                _ctx.Members.Update(entity);
                _ctx.SaveChanges();
                return member;
            }
            return null;

            /*MemberEntity entity = new MemberEntity
            {
                ModelId = member.Id,
                Name = member.Name,
                Phone = member.Phone,
                Email = member.Email
            };

            _ctx.Members.Update(entity);
            _ctx.SaveChanges();
            return member;*/
        }

        // DELETE
        public void DeleteMember(Guid id)
        {
            MemberEntity entity = _ctx.Members.FirstOrDefault(x => x.ModelId == id);
            if(entity != null)
            {
                _ctx.Members.Remove(entity);
                _ctx.SaveChanges();
            }
            /*_ctx.Members.Remove(_ctx.Members.Single(x => x.ModelId == id));*/
        }
        #endregion

        #region Helpers


        /*private Member FromEntity(MemberEntity e)
        {
            return new Member()
            {
                Id = e.ModelId,
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                Password = e.Password,
                Salt = e.Salt
            };
        }*/
        #endregion
    }
}   
   
