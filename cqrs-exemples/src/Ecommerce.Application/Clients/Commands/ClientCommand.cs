using Ecommerce.Application.Core.Commands;
using MediatR;

namespace Ecommerce.Application.Clients.Commands
{
    public abstract class ClientCommand : IRequest<ResponseCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
