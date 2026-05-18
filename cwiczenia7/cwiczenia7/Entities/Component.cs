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
    public ComponentManufacturers ComponentManufacturer { get; set; }
    
    public int ComponentTypeId { get; set; }
    
    [ForeignKey(nameof(ComponentTypeId))]
    public ComponentTypes ComponentTypes { get; set; }
    
    public List<PCComponent> PCComponents { get; set; }
    
}