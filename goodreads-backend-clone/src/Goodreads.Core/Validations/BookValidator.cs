using FluentValidation;
using Goodreads.Core.Entities;

namespace Goodreads.Core.Validations;

public class BookValidator: AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(_ => _.Title).NotNull().NotEmpty();
        RuleFor(_ => _.Summary).NotNull().NotEmpty().MaximumLength(300).WithMessage("Summary maximum length is 300 chars");
        RuleFor(_ => _.Description).NotNull().NotEmpty();
        RuleFor(_ => _.Thumb).NotNull().NotEmpty();
    }
}