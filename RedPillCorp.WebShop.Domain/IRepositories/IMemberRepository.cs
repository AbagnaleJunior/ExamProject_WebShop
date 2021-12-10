using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedPillCorp.WebShop.Application.Models;

namespace RedPillCorp.WebShop.Domain.IRepositories
{
    public interface IMemberRepository
    {
        Member CreateMember(Member newMember);
        Member DeleteMember(Member member);
    }
}
