using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Validators;
using FluentValidation;

namespace Ecommerce.Domain.Validations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.FirstName).FirstName();
            RuleFor(x => x.LastName).LastName();
            RuleFor(x => x.Email).Email();
        }
    }
}
