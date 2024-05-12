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
    public class GetMembersByIdQuery : IRequest<Member>
    {
        public int Id { get; set; }
        public class GetMembersByIdQueryHandlers : IRequestHandler<GetMembersByIdQuery, Member>
        {
            private readonly IMemberDapperRepository _memberDapperRepository;

            public GetMembersByIdQueryHandlers(IMemberDapperRepository memberDapperRepository)
            {
                _memberDapperRepository = memberDapperRepository;
            }

            public async Task<Member> Handle(GetMembersByIdQuery request, CancellationToken cancellationToken)
            {
                var member = await _memberDapperRepository.GetMembersById(request.Id);
                return member;
            }
        }
    }
}
