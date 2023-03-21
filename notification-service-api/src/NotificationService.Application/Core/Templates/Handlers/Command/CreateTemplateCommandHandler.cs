using MediatR;
using NotificationService.Application.Core.Templates.Commands;
using NotificationService.Application.Notifications;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Application.Core.Templates.Handlers.Command
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, GenericResponse>
    {
        private readonly IMediator _mediator;
        private readonly NotificationContext _notification;
        private readonly ITemplateRepository _templateRepository;

        public CreateTemplateCommandHandler(IMediator mediator, NotificationContext notification, ITemplateRepository templateRepository)
        {
            _mediator = mediator;
            _notification = notification;
            _templateRepository = templateRepository;
        }

        public async Task<GenericResponse> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            request.File = request.File.Replace(@"\", @"\\").Replace(@"/", @"\\");

            var f = Path.Combine($"{Directory.GetCurrentDirectory()}\\Templates\\", request.File);

            var template = new Template(request.Title, request.Subject, request.File, request.Type);
            if (!template.Valid)
            {
                _notification.AddNotifications(template.ValidationResult);

                return new GenericResponse
                {
                    Notifications = _notification.Notifications,
                };
            }

            var result = await _templateRepository.AddAsync(template);
            if (result == null)
            {
                _notification.AddNotification("Error", "Error When try to add new template!");

                return new GenericResponse { Notifications = _notification.Notifications, };
            }

            return new GenericResponse
            {
                Result = result,
            };
        }
    }
}
