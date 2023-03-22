using Microsoft.AspNetCore.Mvc;

namespace Consume.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    public PersonsController()
    { }

    [HttpGet]
    public IActionResult Get() =>
        Ok("App is running...");
}