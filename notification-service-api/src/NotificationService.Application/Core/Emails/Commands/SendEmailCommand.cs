using MediatR;

namespace NotificationService.Application.Core.Emails.Commands
{
    public class SendEmailCommand: IRequest<GenericResponse>
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string TemplateBody { get; set; }
        public dynamic? TemplateModel { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string? Attach { get; set; }
    }
}
