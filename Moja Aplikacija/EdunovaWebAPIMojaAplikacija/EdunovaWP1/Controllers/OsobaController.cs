using EdunovaWP1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaWP1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OsobaController : ControllerBase
    {
        [HttpGet]

        [HttpPost]
        public IActionResult Post(Osoba osoba)
        {
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
