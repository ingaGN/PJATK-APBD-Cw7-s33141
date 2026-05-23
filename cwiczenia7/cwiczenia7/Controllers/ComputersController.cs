using cwiczenia7.DAL;
using cwiczenia7.DTO;
using cwiczenia7.Entities;
using cwiczenia7.Exceptions;
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

    [HttpGet]
    [Route("pcs/{id:int}")]
    public async Task<IActionResult> GetPC([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetComponentsById(id, cancellationToken));

        }
        catch(NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPC([FromBody] CreatePCDto pcRequest, CancellationToken cancellationToken)
    {
        var pc = await service.Add(pcRequest, cancellationToken);
        return CreatedAtAction(nameof(GetPC), new { id = pc.Id }, pc);
    }
}