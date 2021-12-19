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

        Member CreateMember(Member member);
        List<Member> ReadAll();
        Member ReadMemberById(Guid id);
        Member ReadMemberByEmail(string email);
        Member UpdateMember(Member member);
        void DeleteMember(Guid id);
       
    }
}
