using MediatR;
using ProductsCleanArch.Application.Products.Core;

namespace ProductsCleanArch.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<ResponseCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
