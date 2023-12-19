using System.Runtime.InteropServices;
using kol02.Models;
using kol02.Services;
using kol2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace kol02.Controllers;
[ApiController]
[Route("api/pets")]

public class PetController : Controller
{
    private IPetDbService _dbService;

    public PetController(IPetDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> getPets([Optional] int year)
    {
        if (year==0)
        {
            Tuple<ICollection<PetDTO>, bool> tuple = await _dbService.GetPets();
            if (!tuple.Item2)
            {
                return NotFound("Exception occured");
            }

            return Ok(tuple.Item1);
        }
        else
        {
            Tuple<ICollection<PetDTO>, bool> tuple = await _dbService.GetPets(year);
            if (!tuple.Item2)
            {
                return NotFound("Exception Occurred");
            }

            return Ok(tuple.Item1);
        }
    }

    [HttpPost]
    public async Task<IActionResult> addPet(PetDTO2 petDto2)
    {
        var s=await _dbService.addPet(petDto2);
        if (s.Equals(("ok")))
        {
            return Ok();
        }

        return Ok(s);
    }
    
}