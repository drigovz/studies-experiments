using FluentValidation;
using Producer.Core.Entities;

namespace Producer.Core.Validations;

public class PersonValidations : AbstractValidator<Person>
{
    public PersonValidations()
    {
        RuleFor(_ => _.FirstName).StringValidation();
        RuleFor(_ => _.LastName).StringValidation();
        RuleFor(_ => _.Email).StringValidation().EmailAddress();
    }
}