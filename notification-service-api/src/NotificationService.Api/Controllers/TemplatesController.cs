using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Core.Templates.Commands;

namespace NotificationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTemplateCommand request)
            => Ok(await _mediator.Send(request));
    }
}
