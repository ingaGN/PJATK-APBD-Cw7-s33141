namespace cwiczenia7.DTO;

public record PCDetailsDto(
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    List<PCComponentDto> PCComponents
    );