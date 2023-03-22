using FluentValidation;
using Goodreads.Core.Entities;

namespace Goodreads.Core.Validations;

public class ReviewValidation : AbstractValidator<Review>
{
    public ReviewValidation()
    {
        RuleFor(_ => _.Comment).NotNull().NotEmpty();
    }
}