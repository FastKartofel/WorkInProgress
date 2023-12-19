namespace kol2.Entities;

public class BreedType
{
    public int IdBreedType { set; get; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
        
    public virtual ICollection<Pet> Pets { get; set; }
}