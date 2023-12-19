using kol02.Models;
using kol2.Entities;

namespace kol02.Services;

public interface IPetDbService
{
    public Task<Tuple<ICollection<PetDTO>, bool>> GetPets(int year);
    public Task<Tuple<ICollection<PetDTO>, bool>> GetPets();
    public Task<string> addPet(PetDTO2 petDto2);
}