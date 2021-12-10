using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using RedPillCorp.WebShop.Domain.IRepositories;

namespace RedPillCorp.WebShop.Domain.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        public Member CreateMember(Member newMember)
        {
            return _repo.CreateMember(newMember);
        }

        public Member DeleteMember(Member member)
        {
            return _repo.DeleteMember(member);
        }
    }
}
