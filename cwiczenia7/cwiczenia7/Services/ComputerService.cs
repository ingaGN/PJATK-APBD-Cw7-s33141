using cwiczenia7.DAL;
using cwiczenia7.DTO;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia7.Services;

public class ComputerService(ComputerDbContext context) : IComputerService
{
    public async Task<IEnumerable<PCDto>> GetAll(CancellationToken cancellationToken )
    {
        return await context.PC.Select(pc => new PCDto(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }
}