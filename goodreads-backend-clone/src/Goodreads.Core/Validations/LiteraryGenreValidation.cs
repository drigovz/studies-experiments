using FluentValidation;
using Goodreads.Core.Entities;

namespace Goodreads.Core.Validations;

internal class LiteraryGenreValidation : AbstractValidator<LiteraryGender>
{
    public LiteraryGenreValidation()
    {
        RuleFor(_ => _.Title).NotNull().NotEmpty();
        RuleFor(_ => _.Description).NotNull().NotEmpty();
    }
}