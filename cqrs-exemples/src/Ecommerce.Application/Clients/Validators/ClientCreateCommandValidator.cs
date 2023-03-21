using Ecommerce.Application.Clients.Commands;
using Ecommerce.Domain.Validators;
using FluentValidation;

namespace Ecommerce.Application.Clients.Validators
{
    public class ClientCreateCommandValidator : AbstractValidator<ClientCreateCommand>
    {
        public ClientCreateCommandValidator()
        {
            RuleFor(x => x.FirstName).FirstName();
            RuleFor(x => x.LastName).LastName();
            RuleFor(x => x.Email).Email();
        }
    }
}
