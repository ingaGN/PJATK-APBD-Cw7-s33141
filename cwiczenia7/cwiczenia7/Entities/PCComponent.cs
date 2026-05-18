using System.ComponentModel.DataAnnotations.Schema;

namespace cwiczenia7.Entities;

[Table("PCComponents")]
public class PCComponent
{
    public int PCId { get; set; }
    
    [ForeignKey(nameof(PCId))]
    public PC PC  { get; set; }
    
    public string ComponentCode { get; set; }
    
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; }

    public int Ammount { get; set; }
    
}