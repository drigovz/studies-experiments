using MediatR;
using ProductsCleanArch.Application.Products.Commands;
using ProductsCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Products.Handlers.Commands
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ApplicationException("Product not found!");

            return await _productRepository.RemoveAsync(product.Id);
        }
    }
}
