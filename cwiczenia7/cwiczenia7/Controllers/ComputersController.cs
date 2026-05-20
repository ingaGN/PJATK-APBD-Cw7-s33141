using cwiczenia7.DAL;
using cwiczenia7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputersController(IComputerService service) : ControllerBase
{
    
    [HttpGet]
    [Route("pcs")]
    public async Task<IActionResult> GetPCs(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAll(cancellationToken));
    }
}