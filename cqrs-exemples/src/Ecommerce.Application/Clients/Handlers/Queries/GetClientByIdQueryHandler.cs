using Ecommerce.Application.Clients.Queries;
using Ecommerce.Application.Core.Commands;
using Ecommerce.Application.Notifications;
using Ecommerce.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Clients.Handlers.Queries
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ResponseCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly NotificationContext _notification;

        public GetClientByIdQueryHandler(IClientRepository clientRepository, NotificationContext notification)
        {
            _clientRepository = clientRepository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client == null)
                return new ResponseCommand
                {
                    Notifications = _notification.AddNotification("Error", $"Client with id {request.Id} not found!"),
                };

            return new ResponseCommand
            {
                Result = client,
            };
        }
    }
}
