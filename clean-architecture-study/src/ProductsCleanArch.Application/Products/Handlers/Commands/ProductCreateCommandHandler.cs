using MediatR;
using ProductsCleanArch.Application.Notifications;
using ProductsCleanArch.Application.Products.Commands;
using ProductsCleanArch.Application.Products.Core;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductsCleanArch.Application.Products.Handlers.Commands
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ResponseCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly NotificationContext _notification;

        public ProductCreateCommandHandler(IProductRepository productRepository, NotificationContext notification)
        {
            _productRepository = productRepository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            if (!product.Valid)
            {
                _notification.AddNotifications(product.ValidationResult);

                return new ResponseCommand
                {
                    Errors = _notification.Notifications,
                };
            }

            var result = await _productRepository.AddAsync(product);
            if (result == null)
            {
                _notification.AddNotification("Database Connection", "Error When try to connect on server!");

                return new ResponseCommand
                {
                    Errors = _notification.Notifications,
                    Result = null,
                };
            }

            return new ResponseCommand { Result = result, };
        }
    }
}
