using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAsync() =>
        Ok("Api 2 Running");
}
