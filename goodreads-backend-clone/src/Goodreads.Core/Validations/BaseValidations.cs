using FluentValidation;

namespace Goodreads.Core.Validations;

public static class BaseValidations
{
    public static IRuleBuilderOptions<T, DateTime> DateTimeValidate<T>(this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.NotNull()
                   .NotEmpty()
                   .WithMessage("Birthdate date is required")
                   .Must(BeAValidDate)
                   .WithMessage("Birthdate must be validate date format!");
    
    private static bool BeAValidDate(DateTime date) =>
        !date.Equals(default(DateTime));
}