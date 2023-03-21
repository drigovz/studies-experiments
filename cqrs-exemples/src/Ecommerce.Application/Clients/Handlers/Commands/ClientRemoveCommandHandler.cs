using Ecommerce.Application.Clients.Commands;
using Ecommerce.Application.Core.Commands;
using Ecommerce.Application.Notifications;
using Ecommerce.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Clients.Handlers.Commands
{
    public class ClientRemoveCommandHandler : IRequestHandler<ClientRemoveCommand, ResponseCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly NotificationContext _notification;

        public ClientRemoveCommandHandler(IClientRepository clientRepository, NotificationContext notification)
        {
            _clientRepository = clientRepository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(ClientRemoveCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
                return new ResponseCommand
                {
                    Notifications = _notification.AddNotification("Error", $"Client with id {request.Id} not found!"),
                };

            await _clientRepository.RemoveAsync(request.Id);
            return new ResponseCommand
            {
                Notifications = _notification.AddNotification("Success", "Client deleted succesfull!"),
            };
        }
    }
}
