using FluentValidation;
using NotificationService.Application.Core.Emails.Commands;

namespace NotificationService.Application.Core.Emails.Validators
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(x => x.To).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.TemplateBody).NotNull().NotEmpty();
        }
    }
}
