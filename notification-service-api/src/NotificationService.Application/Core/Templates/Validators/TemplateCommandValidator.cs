using FluentValidation;
using NotificationService.Application.Core.Templates.Commands;

namespace NotificationService.Application.Core.Templates.Validators
{
    public class TemplateCommandValidator : AbstractValidator<TemplateCommand>
    {
        public TemplateCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.File).NotNull().NotEmpty();
            RuleFor(x => x.Type).NotEmpty().IsInEnum();
        }
    }
}
