using FluentValidation;
using NotificationService.Application.Core.Templates.Commands;

namespace NotificationService.Application.Core.Templates.Validators
{
    public class DeleteTemplateCommandValidator : AbstractValidator<DeleteTemplateCommand>
    {
        public DeleteTemplateCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
