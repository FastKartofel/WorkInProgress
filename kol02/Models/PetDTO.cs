using kol2.Entities;

namespace kol02.Models;

public class PetDTO
{
    public int IdPet { get; set; }
    public int IdBreedType { get; set; }
    public string Name { get; set; }
    public int IsMale { get; set; }
    public DateTime DateRegistered { get; set; }
    public DateTime ApproximatedDateOfBirth { get; set; }
    public DateTime? DateAdopted { get; set; }
    public List<VolunteerDTO> Volunteers { get; set; }
}