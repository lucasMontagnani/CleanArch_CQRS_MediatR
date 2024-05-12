using CleanArch_CQRS_MediatR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Domain.Abstractions
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMembersById(int id);
    }
}
