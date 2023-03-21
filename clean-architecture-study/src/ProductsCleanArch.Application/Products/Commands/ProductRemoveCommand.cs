using MediatR;

namespace ProductsCleanArch.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
