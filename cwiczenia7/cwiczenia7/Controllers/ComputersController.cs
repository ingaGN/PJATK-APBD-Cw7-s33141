using Microsoft.AspNetCore.Mvc;

namespace cwiczenia7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputersController : ControllerBase
{
    public IActionResult Get()
    {
        return Ok();
    }
}