using MediatR;

namespace NotificationService.Application.Core.Templates.Commands
{
    public class DeleteTemplateCommand : IRequest<GenericResponse>
    {
        public int Id { get; set; }
    }
}
