using CleanArch_CQRS_MediatR.Application.Members.Commands.Notifications;
using CleanArch_CQRS_MediatR.Domain.Abstractions;
using CleanArch_CQRS_MediatR.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Commands
{
    public sealed class CreateMemberCommand : MemberCommandBase
    { 
        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
        {
            private readonly IUnitOfWork _unitOfWork;
            //private readonly IValidator<CreateMemberCommand> _validator;
            private readonly IMediator _mediator;

            public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMediator mediator
                //, IValidator<CreateMemberCommand> validator
                )
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
                //_validator = validator;
            }
            public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                // Validacao via FluentValidator configurado em Validations e registrado nos serviços
                //_validator.ValidateAndThrow(request);

                Member newMember = new(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

                await _unitOfWork.MemberRepository.AddMember(newMember);
                await _unitOfWork.CommitAsync();

                await _mediator.Publish(new MemberCreatedNotification(newMember), cancellationToken);

                return newMember;
            }
        }
    }
}
