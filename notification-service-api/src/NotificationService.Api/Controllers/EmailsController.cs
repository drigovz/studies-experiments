using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Core.Emails.Commands;

namespace NotificationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand request)
            => Ok(await _mediator.Send(request));
    }
}
