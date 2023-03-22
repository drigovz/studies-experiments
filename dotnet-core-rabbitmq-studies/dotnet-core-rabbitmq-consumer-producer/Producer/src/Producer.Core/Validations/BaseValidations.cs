using FluentValidation;

namespace Producer.Core.Validations;

public static class BaseValidations
{
    public static IRuleBuilderOptions<T, string> StringValidation<T>(this IRuleBuilder<T, string> builder) =>
        builder.NotNull().NotEmpty();
}