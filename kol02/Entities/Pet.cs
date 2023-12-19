namespace kol2.Entities;

public class Pet
{
    public int IdPet { get; set; }
    public int IdBreedType { get; set; }
    public string Name { get; set; }
    public int IsMale { get; set; }
    public DateTime DateRegistered { get; set; }
    public DateTime ApproximatedDateOfBirth { get; set; }
    public DateTime? DateAdopted { get; set; }
    
    public virtual BreedType BreedType { get; set; }
    public virtual ICollection<VolunteerPet> VolunteerPets { get; set; }
}