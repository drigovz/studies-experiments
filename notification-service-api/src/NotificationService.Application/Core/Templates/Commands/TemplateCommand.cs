using MediatR;
using NotificationService.Domain.Enums;

namespace NotificationService.Application.Core.Templates.Commands
{
    public class TemplateCommand : IRequest<GenericResponse>
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public string File { get; set; }
        public TemplateType Type { get; set; }
    }
}
