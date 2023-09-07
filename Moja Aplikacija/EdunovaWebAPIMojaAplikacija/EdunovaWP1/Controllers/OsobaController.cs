using EdunovaWP1.Data;
using EdunovaWP1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaWP1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OsobaController : ControllerBase
    {
        private readonly EdunovaContext _context;
        public OsobaController(EdunovaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Osoba.ToList());
        }

        [HttpPost]
        public IActionResult Post(Osoba osoba)
        {
            _context.Osoba.Add(osoba);
            _context.SaveChanges();

            return Created("/api/v1/osoba", osoba);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(Osoba osoba)
        {

            return StatusCode(StatusCodes.Status200OK, osoba);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");
        }
    }
}
