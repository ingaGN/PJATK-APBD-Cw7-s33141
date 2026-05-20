namespace cwiczenia7.DTO;

public record ComponentDto(
    string Code,
    string Name,
    string Description,
    ManufacturerDto Manufacturers,
    ComponentTypeDto ComponentTypes);