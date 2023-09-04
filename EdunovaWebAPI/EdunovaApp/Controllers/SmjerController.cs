using EdunovaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller])")]
    public class SmjerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var lista = new List<Smjer>()
            {
                new () {Naziv = "prvi"},
                new () {Naziv = "drugi"}
            };
            return new JsonResult(lista);
        }

        [HttpPost]
        public IActionResult Post(Smjer smjer)
        {
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
