using System.ComponentModel.DataAnnotations.Schema;

namespace cwiczenia7.Entities;

[Table("PCComponents")]
public class PCComponent
{
    public int IdPC { get; set; }
    public PC PC { get; set; }
    
    public int IdComponent { get; set; }
    public Component Component { get; set; }

    public int Ammount { get; set; }
    
}