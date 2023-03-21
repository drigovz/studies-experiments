using FluentValidation;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name is required!");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Name need more than 2 chars!");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description is required!");

            RuleFor(x => x.Description)
                .MinimumLength(6)
                .WithMessage("Description need more than 5 chars!");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Invalid price value!");

            RuleFor(x => x.Stock)
                .GreaterThan(0)
                .WithMessage("Invalid stock value!");

            RuleFor(x => x.Image)
                .MaximumLength(250)
                .WithMessage("Invalid image name, too long, maximum 250 characters!");
        }
    }
}
