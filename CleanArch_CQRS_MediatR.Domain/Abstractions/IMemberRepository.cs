using CleanArch_CQRS_MediatR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Domain.Abstractions
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMemberById(int memberId);
        Task<Member> AddMember(Member member);
        void UpdateMember(Member member);
        Task<Member> DeleteMember(int memberId);
    }
}
