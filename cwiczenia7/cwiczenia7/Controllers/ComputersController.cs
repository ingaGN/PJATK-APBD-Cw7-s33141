using cwiczenia7.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComputersController : ControllerBase
{
    
    private ComputerDbContext _dbContext;
    public ComputersController(ComputerDbContext context)
    {
        _dbContext = context;
    }
    
    [HttpGet]
    [Route("pcs")]
    public async Task<IActionResult> GetPCs()
    {
        var pcs = await _dbContext.PC
            .ToListAsync();
        return Ok(pcs);
    }
}