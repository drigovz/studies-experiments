using MediatR;
using Microsoft.AspNetCore.Mvc;
using Producer.Application.Core.Persons.Commands;

namespace Producer.Api.Controllers;

[ApiController]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonCreateCommand request) =>
        Ok(await _mediator.Send(request));
}