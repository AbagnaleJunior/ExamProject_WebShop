using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;

namespace RedPillCorp.WebShop.Domain.IRepositories
{
    public interface IMemberRepository
    {
        #region Database - for test

        void ResetDatabase();
        void FeedDatabase();
        #endregion

        #region CRUD
        Member CreateMember(Member member);
        Member ReadMemberById(Guid id);
        List<Member> ReadAll();
        Member UpdateMember(Member member);
        void DeleteMember(Guid id);
        Member ReadMemberByEmail(string email);
        
        #endregion
    }
}
