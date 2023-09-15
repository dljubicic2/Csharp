using EdunovaWP1.Data;
using EdunovaWP1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var osobe = _context.Osoba.ToList();
                if(osobe==null || osobe.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Osoba.ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                                    ex.Message);
            }
            
          
        }

        [HttpPost]
        public IActionResult Post(Osoba osoba)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Osoba.Add(osoba);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, osoba);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                    ex.Message);
            }


            
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Osoba osoba)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }
            try
            {
                var osobaBaza = _context.Osoba.Find(sifra);
                if(osobaBaza == null)
                {
                    return BadRequest();
                }
                osobaBaza.Nadimak = osoba.Nadimak;
                osoba.Email = osoba.Email;
                osoba.Lozinka = osoba.Lozinka;
                osoba.BrojTelefona = osoba.BrojTelefona;

                _context.Osoba.Update(osobaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, osobaBaza);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                    ex.Message);

            }

        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }
            try
            {
                var osobaBaza = _context.Osoba.Find(sifra);
                if (osobaBaza == null)
                {
                    return BadRequest();
                }

                _context.Osoba.Remove(osobaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {
                try
                {
                    SqlException sqle = (SqlException)ex;
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   sqle);
                }
                catch (Exception e)
                {

                    
                }

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                    ex.Message);

            }
        }
    }
}
