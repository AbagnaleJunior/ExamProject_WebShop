using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedPillCorp.WebShop.Domain.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repo;


        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        #region Database setup

        public void DatabaseSetup()
        {
            _repo.ResetDatabase();
            _repo.FeedDatabase();
        }
        #endregion

        #region CRUD
        // CREATE
        public Member CreateMember(Member member)
        {
            return _repo.CreateMember(member);
        }
        // READ
        public Member ReadMemberById(Guid id)
        {
            return _repo.ReadMemberById(id);
        }
        public Member ReadMemberByEmail(string email)
        {
            Member member = _repo.ReadMemberByEmail(email);
            /*System.IO.File.WriteAllText(@"D:\test\member.txt", member.Email);*/
                return member;
        }
        // READ ALL
        public List<Member> ReadAll()
        {
            return _repo.ReadAll();
        }
        // UPDATE
        public Member UpdateMember(Member member)
        {
            return _repo.UpdateMember(member);
        }
        // DELETE
        public void DeleteMember(Guid id)
        {
            _repo.DeleteMember(id);
        }
        #endregion

        #region For later purpose
        /*public Member Login(string email, string password)
        {
            Member member = _repo.ReadMemberByEmail(email);

            string passwordWithSalt = Cryptography.Crypto.GetHashWithSalt(password, salt)
            
        }*/
        #endregion
    }
}
