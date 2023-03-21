using Ecommerce.Application.Clients.Commands;
using Ecommerce.Application.Core.Commands;
using Ecommerce.Application.Notifications;
using Ecommerce.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Clients.Handlers.Commands
{
    public class ClientUpdateCommandHandler : IRequestHandler<ClientUpdateCommand, ResponseCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly NotificationContext _notification;

        public ClientUpdateCommandHandler(IClientRepository clientRepository, NotificationContext notification)
        {
            _clientRepository = clientRepository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
                return new ResponseCommand
                {
                    Notifications = _notification.AddNotification("Error", $"Client with id {request.Id} not found!"),
                };

            client.Update(request.FirstName, request.LastName, request.Email);
            await _clientRepository.UpdateAsync(client);

            return new ResponseCommand
            {
                Result = client,
                Notifications = _notification.AddNotification("Success", $"Client with id {request.Id} update succesfull!"),
            };
        }
    }
}
