using Ecommerce.Application.Core.Commands;
using MediatR;

namespace Ecommerce.Application.Clients.Commands
{
    public class ClientRemoveCommand : IRequest<ResponseCommand>
    {
        public int Id { get; set; }
    }
}
