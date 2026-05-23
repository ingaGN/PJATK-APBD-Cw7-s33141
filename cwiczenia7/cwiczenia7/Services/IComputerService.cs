using cwiczenia7.DTO;

namespace cwiczenia7.Services;

public interface IComputerService
{
    Task<IEnumerable<PCDto>> GetAll(CancellationToken cancellationToken);
    Task<IEnumerable<PCDetailsDto>> GetComponentsById(int IdPC, CancellationToken cancellationToken);

    Task<ResponsePC> Add(CreatePCDto dto, CancellationToken cancellationToken);

}