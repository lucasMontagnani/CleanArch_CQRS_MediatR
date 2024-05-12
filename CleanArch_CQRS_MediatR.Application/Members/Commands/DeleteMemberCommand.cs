using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Commands
{
    public sealed class DeleteMemberCommand : IRequest<Member>
    {
        public int Id { get; set; }

        public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Member>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Member> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
            {
                var deleteMember = await _unitOfWork.MemberRepository.DeleteMember(request.Id);

                if (deleteMember == null)
                {
                    throw new InvalidOperationException("Member not found.");
                }

                await _unitOfWork.CommitAsync();
                return deleteMember;
            }
        }
    }
}
