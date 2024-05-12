using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Queries
{
    public class GetMembersQuery : IRequest<IEnumerable<Member>>
    {
        public class GetMembersQueryHandlers : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
        {
            private readonly IMemberDapperRepository _memberDapperRepository;

            public GetMembersQueryHandlers(IMemberDapperRepository memberDapperRepository)
            {
                _memberDapperRepository = memberDapperRepository;
            }

            public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
            {
                var members = await _memberDapperRepository.GetMembers();
                return members;
            }
        }
    }
}
