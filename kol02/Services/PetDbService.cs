using kol02.Models;
using kol2.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace kol02.Services;

public class PetDbService:IPetDbService
{
    private PetDbContext _dbContext;

    public PetDbService(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tuple<ICollection<PetDTO>, bool>> GetPets(int year)
    {
        try
        {
            List<PetDTO> list = await _dbContext.Pets.Where(pet=>pet.DateRegistered.Year==year).Select(pet => new PetDTO()
            {
                IdPet = pet.IdPet, Name = pet.Name, IdBreedType = pet.IdBreedType, IsMale = pet.IsMale,
                DateRegistered = pet.DateRegistered, ApproximatedDateOfBirth = pet.ApproximatedDateOfBirth,
                DateAdopted = pet.DateAdopted,
                Volunteers = pet.VolunteerPets.Select(volunteerPet => new VolunteerDTO()
                {
                    Name = volunteerPet.Volunteer.Name, Surname = volunteerPet.Volunteer.Surname,
                    Phone = volunteerPet.Volunteer.Phone
                }).ToList()
            }).OrderBy(pet=>pet.DateRegistered).ToListAsync();
            return new Tuple<ICollection<PetDTO>, bool>(list, true);
        }
        catch(Exception e)
        {
            return new Tuple<ICollection<PetDTO>, bool>(new List<PetDTO>(), false);
        }
    }

    public async Task<Tuple<ICollection<PetDTO>,bool>> GetPets()
    {
        try
        {
            List<PetDTO> list = await _dbContext.Pets.Select(pet => new PetDTO()
            {
                IdPet = pet.IdPet, Name = pet.Name, IdBreedType = pet.IdBreedType, IsMale = pet.IsMale,
                DateRegistered = pet.DateRegistered, ApproximatedDateOfBirth = pet.ApproximatedDateOfBirth,
                DateAdopted = pet.DateAdopted,
                Volunteers = pet.VolunteerPets.Select(volunteerPet => new VolunteerDTO()
                {
                    Name = volunteerPet.Volunteer.Name, Surname = volunteerPet.Volunteer.Surname,
                    Phone = volunteerPet.Volunteer.Phone
                }).ToList()
            }).OrderBy(pet=>pet.DateRegistered).ToListAsync();
            return new Tuple<ICollection<PetDTO>, bool>(list, true);
        }
        catch(Exception e)
        {
            return new Tuple<ICollection<PetDTO>, bool>(new List<PetDTO>(), false);
        }
    }

    public async Task<string> addPet(PetDTO2 petDto2)
    {
     
            var mabeidBreedType =
                await _dbContext.BreedTypes.FirstOrDefaultAsync(type => type.Name.Equals(petDto2.Name));
            if (mabeidBreedType == null)
            {
                BreedType breedType = new BreedType() { Name = petDto2.BreedName };
                _dbContext.BreedTypes.Add(breedType);
                await _dbContext.SaveChangesAsync();
                mabeidBreedType = breedType;
            }

            Pet pet = new Pet()
            {
                Name = petDto2.Name, IsMale = petDto2.IsMale, DateRegistered = petDto2.DateRegistered,
                ApproximatedDateOfBirth = petDto2.ApproximatedDateOfBirth, IdBreedType = mabeidBreedType.IdBreedType
            };
            _dbContext.Pets.Add(pet);
            await _dbContext.SaveChangesAsync();
            return "ok";

    }
}