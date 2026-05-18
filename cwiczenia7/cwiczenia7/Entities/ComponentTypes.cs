namespace cwiczenia7.Entities;

public class ComponentTypes
{
    public int Id { get; set; }
    public string Abreviation { get; set; }
    public string Name { get; set; }
    
    public List<Component> Components { get; set; }
}