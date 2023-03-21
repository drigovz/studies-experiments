using MediatR;
using ProductsCleanArch.Application.Products.Commands;
using ProductsCleanArch.Application.Products.Core;
using ProductsCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Products.Handlers.Commands
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ResponseCommand>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseCommand> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ApplicationException("Product not found!");

            product.UpdateProduct(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            await _productRepository.UpdateAsync(product);

            return new ResponseCommand();
        }
    }
}
