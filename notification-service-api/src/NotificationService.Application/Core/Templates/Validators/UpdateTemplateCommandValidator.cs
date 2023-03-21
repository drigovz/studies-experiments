using FluentValidation;
using NotificationService.Application.Core.Templates.Commands;

namespace NotificationService.Application.Core.Templates.Validators
{
    public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
    {
        public UpdateTemplateCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.File).NotNull().NotEmpty();
            RuleFor(x => x.Type).NotNull().NotEmpty().IsInEnum();
        }
    }
}
