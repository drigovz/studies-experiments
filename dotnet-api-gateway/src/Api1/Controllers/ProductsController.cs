using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAsync() =>
        Ok("Api 1 Running");
}
