using System.ComponentModel.DataAnnotations.Schema;

namespace cwiczenia7.Entities;

[Table("Components")]
public class Component
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int IdManufacurer { get; set; }
    
    [ForeignKey(nameof(IdManufacurer))]
    public ComponentManufacturers ComponentManufacturerId { get; set; }
    
    public int ComponentId { get; set; }
    
    [ForeignKey(nameof(ComponentId))]
    public ComponentTypes ComponentTypesId { get; set; }

    public List<PCComponent> PCs { get; set; } = new();

}