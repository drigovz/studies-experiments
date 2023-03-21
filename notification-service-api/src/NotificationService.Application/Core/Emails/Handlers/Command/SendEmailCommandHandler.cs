using FluentEmail.Core;
using MediatR;
using NotificationService.Application.Config;
using NotificationService.Application.Core.Emails.Commands;
using NotificationService.Application.Notifications;

namespace NotificationService.Application.Core.Emails.Handlers.Command
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, GenericResponse>
    {
        private readonly IMediator _mediator;
        private readonly NotificationContext _notification;
        private readonly IFluentEmail _fluentEmail;

        public SendEmailCommandHandler(IMediator mediator, NotificationContext notification, IFluentEmail fluentEmail)
        {
            _mediator = mediator;
            _notification = notification;
            _fluentEmail = fluentEmail;
        }

        public async Task<GenericResponse> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = TemplateConfiguration.Build(new { Name = "Exemple", Email = request.To }, $"Emails\\Index.cshtml");

            var email = _fluentEmail.To(request.To)
                        .Subject(request.Subject)
                        .Body(result, true);

            if (!string.IsNullOrWhiteSpace(request.Cc))
                email.CC(request.Cc);

            if (!string.IsNullOrWhiteSpace(request.Bcc))
                email.BCC(request.Bcc);

            //if (!string.IsNullOrWhiteSpace(request.Attach))
            //    email.Attach(request.Attach);

            var emailResult = await email.SendAsync();
            if (emailResult?.ErrorMessages?.Count > 0)
            {
                foreach (var error in emailResult?.ErrorMessages)
                    _notification.AddNotification($"Mail Error", error);

                return new GenericResponse
                {
                    Notifications = _notification.Notifications,
                };
            }

            return new GenericResponse
            {
                Result = "Success - mail sended!",
            };
        }
    }
}
