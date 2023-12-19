using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzygotowaniaDoTestu2.DAL;
using System.Reflection.Metadata.Ecma335;

namespace PrzygotowaniaDoTestu2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly Kolos2Context _context;

        public StudentController(Kolos2Context context) 
        {
            _context = context;
        }





        [HttpGet]
        public IActionResult GetStudent()
        {
            var s = _context.Students.ToList();
            return Ok(s);
        }
    }
}
