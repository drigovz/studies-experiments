using Ecommerce.Application.Clients.Queries;
using Ecommerce.Application.Core.Commands;
using Ecommerce.Application.Notifications;
using Ecommerce.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Clients.Handlers.Queries
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, ResponseCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly NotificationContext _notification;

        public GetClientsQueryHandler(IClientRepository clientRepository, NotificationContext notification)
        {
            _clientRepository = clientRepository;
            _notification = notification;
        }

        public async Task<ResponseCommand> Handle(GetClientsQuery request, CancellationToken cancellationToken)
            => new ResponseCommand { Result = await _clientRepository.GetAsync(), };
    }
}
