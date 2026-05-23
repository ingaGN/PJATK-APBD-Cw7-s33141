namespace cwiczenia7.DTO;

public record CreatePCDto(
    string Name,
    float Weight,
    int Warranty,
    int Stock);