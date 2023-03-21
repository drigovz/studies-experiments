using Ecommerce.Application.Clients.Commands;
using Ecommerce.Application.Clients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientCreateCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([BindRequired] int id)
            => Ok(await _mediator.Send(new GetClientByIdQuery { Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetClientsQuery()));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([BindRequired] int id, ClientUpdateCommand command)
            => Ok(await _mediator.Send(command));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([BindRequired] int id)
            => Ok(await _mediator.Send(new ClientRemoveCommand { Id = id }));
    }
}
