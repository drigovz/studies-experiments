using Ecommerce.Application.Clients.Commands;
using Ecommerce.Application.Core.Commands;
using Ecommerce.Application.Notifications;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Clients.Handlers.Commands
{
    public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, ResponseCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly NotificationContext _notification;

        public ClientCreateCommandHandler(IClientRepository clientRepository, NotificationContext notification)
        {
            _clientRepository = clientRepository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.FirstName, request.LastName, request.Email);
            if (!client.Valid)
            {
                _notification.AddNotifications(client.ValidationResult);

                return new ResponseCommand
                {
                    Notifications = _notification.Notifications,
                };
            }

            var result = await _clientRepository.AddAsync(client);
            if (result == null)
            {
                _notification.AddNotification("Database Connection", "Error When try to add new client!");

                return new ResponseCommand { Notifications = _notification.Notifications, };
            }

            return new ResponseCommand { Result = result, };
        }
    }
}
