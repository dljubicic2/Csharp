using EdunovaApp.Data;
using EdunovaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller])")]
    public class SmjerController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public SmjerController(EdunovaContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {

            return new JsonResult(_context.Smjer.ToList());
        }

        [HttpPost]
        public IActionResult Post(Smjer smjer)
        {
            _context.Smjer.Add(smjer);
            _context.SaveChanges();

            // Dodavanje u bazu
            return Created("/api/v1/Smjer", smjer); //201
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(Smjer smjer, int sifra)
        {
            // Promjena u bazi

            return StatusCode(StatusCodes.Status200OK, smjer);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            // Brisanje u bazi
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");

        }
    }
}
