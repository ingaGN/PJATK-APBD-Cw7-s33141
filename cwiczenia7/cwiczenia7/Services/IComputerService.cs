using cwiczenia7.DTO;

namespace cwiczenia7.Services;

public interface IComputerService
{
    Task<IEnumerable<PCDto>> GetAll(CancellationToken cancellationToken);
}