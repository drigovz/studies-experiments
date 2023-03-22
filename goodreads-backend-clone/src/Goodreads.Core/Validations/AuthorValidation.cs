using FluentValidation;
using Goodreads.Core.Entities;
using Goodreads.Core.Enums;

namespace Goodreads.Core.Validations;

public class AuthorValidation : AbstractValidator<Author>
{
    public AuthorValidation()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty();
        RuleFor(_ => _.City).NotNull().NotEmpty();
        RuleFor(_ => _.State).NotNull().NotEmpty();
        RuleFor(_ => _.Country).NotNull().NotEmpty();
        RuleFor(_ => _.Birthdate).DateTimeValidate();
        RuleFor(_ => _.Gender).Must(IsValidEnumValue);
    }
    
    private static bool IsValidEnumValue(Gender value)
    {
        var result = Enum.IsDefined(typeof(Gender), value);
        return result;
    }
}