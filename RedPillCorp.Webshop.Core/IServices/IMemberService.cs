using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;

namespace RedPillCorp.WebShop.Application.IServices
{
    public interface IMemberService
    {
        #region Database setup - for test

        public void DatabaseSetup();
        #endregion

        // CREATE
        Member CreateMember(Member member);
        // READ (by Id)
        Member ReadMemberById(Guid id);
        // READ (by Email)
        Member ReadMemberByEmail(string email);
        // READ ALL
        List<Member> ReadAll();
        // UPDATE
        Member UpdateMember(Member member);
        // DELETE
        void DeleteMember(Guid id);

    }
}
