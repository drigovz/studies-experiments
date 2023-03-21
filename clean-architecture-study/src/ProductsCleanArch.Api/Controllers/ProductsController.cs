using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsCleanArch.Application.Products.Commands;
using ProductsCleanArch.Application.Products.Queries;
using ProductsCleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
            => await _mediator.Send(new GetProductsQuery());
    }
}
