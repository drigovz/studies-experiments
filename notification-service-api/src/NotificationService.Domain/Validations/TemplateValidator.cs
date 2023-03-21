using FluentValidation;
using NotificationService.Domain.Entities;

namespace NotificationService.Domain.Validations
{
    public class TemplateValidator : AbstractValidator<Template>
    {
        public TemplateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotEmpty();
            RuleFor(x => x.Subject).NotEmpty().NotEmpty();
            RuleFor(x => x.File).NotEmpty().NotEmpty();
            RuleFor(x => x.Type).NotEmpty().NotEmpty().IsInEnum();
        }
    }
}
