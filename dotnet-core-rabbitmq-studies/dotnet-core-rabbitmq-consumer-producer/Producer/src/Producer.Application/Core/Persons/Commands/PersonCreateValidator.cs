using FluentValidation;
using Producer.Core.Validations;

namespace Producer.Application.Core.Persons.Commands;

public class PersonCreateValidator : AbstractValidator<PersonCreateCommand>
{
    public PersonCreateValidator()
    {
        RuleFor(_ => _.FirstName).StringValidation();
        RuleFor(_ => _.LastName).StringValidation();
        RuleFor(_ => _.Email).EmailAddress();
    }
}