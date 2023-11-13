using Microsoft.AspNetCore.Mvc;
using teretana.Data;
using teretana.Models;
using Microsoft.Data.SqlClient;

namespace teretana.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class KorisnikController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public KorisnikController(EdunovaContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var korisnici = _context.Korisnik.ToList();
                if(korisnici==null || korisnici.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Korisnik.ToList());
            }
            catch (Exception ex)
            {

               return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Korisnik.Add(korisnik);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, korisnik);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Korisnik korisnik)
        {
            if(sifra <= 0 || korisnik == null)
            {
                return BadRequest();
            }

            try
            {
                var korisnikBaza = _context.Korisnik.Find(sifra);
                if(korisnikBaza == null)
                {
                    return BadRequest();
                }

                korisnikBaza.Ime = korisnik.Ime;
                korisnikBaza.Prezime = korisnik.Prezime;
                korisnikBaza.BrojIskaznice = korisnik.BrojIskaznice;

                _context.Korisnik.Update(korisnik);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, korisnikBaza);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if(sifra <= 0)
            {
                return BadRequest();
            }

            var korisnikBaza = _context.Korisnik.Find(sifra);
            if(korisnikBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Korisnik.Remove(korisnikBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
                
            }
        }
    }
}
