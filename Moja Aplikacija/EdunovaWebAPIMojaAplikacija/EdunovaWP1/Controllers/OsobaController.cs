using EdunovaWP1.Data;
using EdunovaWP1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EdunovaWP1.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije nad entitetom smjer u bazi!
    /// </summary>
    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OsobaController : ControllerBase
    {
        // Dependency injection u controller
        
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

            /// <summary>
            /// Dohvaća sve osobe iz baze
            /// </summary>
            /// <remarks>
            /// <returns></returns>


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

            /// <summary>
            /// Dodaje osobu u bazu
            /// </summary>
            /// <remarks>
            /// <returns></returns>



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
              

                _context.Osoba.Update(osobaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, osobaBaza);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                    ex.Message);

            }

            /// <summary>
            /// Mijenja postojeću osobu u bazi
            /// </summary>
            /// <remarks>
            /// <returns></returns>

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

            var osobaBaza = _context.Osoba.Find(sifra);
            if(osobaBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Osoba.Remove(osobaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {
                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");

            }
        }

        /// <summary>
        /// Briše osobu iz baze
        /// </summary>
        /// <remarks>
        /// <returns></returns>
    }
}
