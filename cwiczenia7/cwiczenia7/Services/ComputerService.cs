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

    public async Task<IEnumerable<PCDetailsDto>> GetComponentsById(int IdPC, CancellationToken cancellationToken)
    {
        return await context.PC
            .Where(e => e.Id == IdPC)
            .Select(pc => new PCDetailsDto(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(pcc => new PCComponentDto(
                        pcc.Ammount,

                        new ComponentDto(
                            pcc.Component.Code,
                            pcc.Component.Name,
                            pcc.Component.Description,

                            new ManufacturerDto(
                                pcc.Component.ComponentManufacturer.Id,
                                pcc.Component.ComponentManufacturer.Abreviation,
                                pcc.Component.ComponentManufacturer.FullName,
                                pcc.Component.ComponentManufacturer.FoundationDate),
                            
                            new ComponentTypeDto(
                                pcc.Component.ComponentTypes.Id, 
                                pcc.Component.ComponentTypes.Abreviation,
                                pcc.Component.ComponentTypes.Name

                            )
                        )
                    
                )).ToList()
            )).ToListAsync(cancellationToken);
    }
}