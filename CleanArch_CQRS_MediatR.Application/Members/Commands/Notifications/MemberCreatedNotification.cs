using CleanArch_CQRS_MediatR.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Commands.Notifications
{
    public class MemberCreatedNotification : INotification
    {
        public Member Member { get; }

        public MemberCreatedNotification(Member member)
        {
            Member = member;
        }
    }
}
