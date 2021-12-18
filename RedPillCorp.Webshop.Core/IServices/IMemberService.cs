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

        #region CRUD

        // CREATE
        Member CreateMember(Member member);

        // READ
        Member ReadMemberById(Guid id);
        Member ReadMemberByEmail(string email);

        // READ ALL
        List<Member> ReadAll();

        // UPDATE
        Member UpdateMember(Member member);

        // DELETE
        void DeleteMember(Guid id);

        #endregion
    }
}
