using Ecommerce.Application.Clients.Commands;
using Ecommerce.Domain.Validators;
using FluentValidation;

namespace Ecommerce.Application.Clients.Validators
{
    public class ClientUpdateCommandValidator : AbstractValidator<ClientUpdateCommand>
    {
        public ClientUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).FirstName();
            RuleFor(x => x.LastName).LastName();
            RuleFor(x => x.Email).Email();
        }
    }
}
