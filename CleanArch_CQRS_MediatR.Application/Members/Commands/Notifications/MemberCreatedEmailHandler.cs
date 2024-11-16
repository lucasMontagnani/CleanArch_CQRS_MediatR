using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CQRS_MediatR.Application.Members.Commands.Notifications
{
    public class MemberCreatedEmailHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedNotification>? _logger;

        public MemberCreatedEmailHandler(ILogger<MemberCreatedNotification>? logger)
        {
            _logger = logger;
        }

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            // Send a confirmation e-mail
            _logger.LogInformation($"Confirmation e-mail send for: {notification.Member.Email}");

            // Email sender logic

            return Task.CompletedTask;
        }
    }
}
