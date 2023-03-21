using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsCleanArch.Application.Products.Queries;
using System.Threading.Tasks;

namespace ProductsCleanArch.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await _mediator.Send(new GetProductsQuery()));
    }
}
