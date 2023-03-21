using Ecommerce.Application.Core.Commands;
using MediatR;

namespace Ecommerce.Application.Clients.Queries
{
    public class GetClientsQuery : IRequest<ResponseCommand>
    { }
}
