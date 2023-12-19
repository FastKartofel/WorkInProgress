using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2Proba.Models;
using test2Proba.DTOs;
using Microsoft.EntityFrameworkCore;

namespace test2Proba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly MainDbContext _context;

        public PetController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetPets(int? year)
        {
            var pets = _context.Pet.AsQueryable();

            if (year.HasValue)
            {
                pets = pets.Where(p => p.DateRegistered.Year >= year);
            }

            var result = await pets.OrderBy(p => p.DateRegistered)
                .Select(p => new PetDto
                {
                    IdPet = p.IdPet,
                    Name = p.Name,
                    DateRegistered = p.DateRegistered,
                    Volunteers = p.VolunteerPets.Select(vp => new VolunteerDto
                    {
                        IdVolunteer = vp.Volunteer.IdVolunteer,
                        Name = vp.Volunteer.Name,
                        Surname = vp.Volunteer.Surname,
                        Phone = vp.Volunteer.Phone
                    }).ToList()
                }).ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(PetDto petDto)
        {
            var breedType = await _context.BreedType.FirstOrDefaultAsync(b => b.Name == petDto.BreedName);
            if (breedType == null)
            {
                breedType = new BreedType { Name = petDto.BreedName };
                _context.BreedType.Add(breedType);
            }

            var pet = new Pet
            {
                Name = petDto.Name,
                IsMale = petDto.IsMale,
                DateRegistered = petDto.DateRegistered,
                ApproximateDateOfBirth = petDto.ApproximateDateOfBirth,
                BreedType = breedType
            };

            _context.Pet.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPets), new { id = pet.IdPet }, pet);
        }


    }
}
