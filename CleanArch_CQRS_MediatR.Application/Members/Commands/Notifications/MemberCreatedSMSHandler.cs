using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Commands.Notifications
{
    public class MemberCreatedSMSHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedNotification>? _logger;

        public MemberCreatedSMSHandler(ILogger<MemberCreatedNotification>? logger)
        {
            _logger = logger;
        }
        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            // Send a confirmation e-mail
            _logger.LogInformation($"Confirmation SMS send for: {notification.Member.FirstName} {notification.Member.LastName}");

            // SMS sender logic

            return Task.CompletedTask;
        }
    }
}
