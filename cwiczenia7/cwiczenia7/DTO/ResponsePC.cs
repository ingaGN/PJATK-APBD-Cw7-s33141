namespace cwiczenia7.DTO;

public record ResponsePC(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock);
