using Ecommerce.Application.Core.Commands;
using MediatR;

namespace Ecommerce.Application.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<ResponseCommand>
    {
        public int Id { get; set; }
    }
}
