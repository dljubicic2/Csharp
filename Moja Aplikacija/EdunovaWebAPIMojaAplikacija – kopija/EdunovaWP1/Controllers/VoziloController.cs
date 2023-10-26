using EdunovaWP1.Data;
using EdunovaWP1.Models;
using EdunovaWP1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EdunovaWP1.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije nad Vozilom!
    /// </summary>
   
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VoziloController :ControllerBase
    {
        private readonly EdunovaContext _context;
        private readonly ILogger<VoziloController> _logger;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>

        public VoziloController(EdunovaContext context, 
            ILogger<VoziloController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vozila = _context.Vozilo.ToList();

            if(vozila==null || vozila.Count == 0)
            {
                return new EmptyResult();
            }

            List<VoziloDTO> vrati = new();

            vozila.ForEach(v =>
            {
                var vdto = new VoziloDTO()
                {
                    Sifra = v.Sifra,
                    Model = v.Model,
                    Marka = v.Marka,
                    Pogon = v.Pogon,
                    Kilometraza = v.Kilometraza,
                    Godiste = v.Godiste

                };

                vrati.Add(vdto);  
                    
            });
            
            return Ok(vrati);
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            if (sifra <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var v = _context.Vozilo.Find(sifra);
                if (v == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, v);
                }
                return new JsonResult(v);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);

            }
        }

        [HttpPost]
        public IActionResult Post(VoziloDTO voziloDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (voziloDTO.SifraOsoba <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var osoba = _context.Osoba.Find(voziloDTO.SifraOsoba);

                if (osoba == null)
                {
                    return BadRequest(ModelState);
                }

                Vozilo v = new()
                {
                    Marka = voziloDTO.Marka,
                    Model = voziloDTO.Model,
                    Pogon = voziloDTO.Pogon,
                    Kilometraza = voziloDTO.Kilometraza,
                    Godiste = voziloDTO.Godiste,
                    Osoba = osoba
                };

                _context.Vozilo.Add(v);
                _context.SaveChanges();

                voziloDTO.Sifra = v.Sifra;
                voziloDTO.Osoba = osoba.Nadimak;

                return Ok(voziloDTO);
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
                
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Vozilo Vozilo)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }
            try
            {
                var voziloBaza = _context.Vozilo.Find(sifra);
                if (voziloBaza == null)
                {
                    return BadRequest();
                }
                voziloBaza.Marka = Vozilo.Marka;
                voziloBaza.Model = Vozilo.Model;
                voziloBaza.Pogon = Vozilo.Pogon;
                voziloBaza.Kilometraza = Vozilo.Kilometraza;
                voziloBaza.Godiste=Vozilo.Godiste;

                _context.Vozilo.Update(voziloBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, voziloBaza);
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
                var voziloBaza = _context.Vozilo.Find(sifra);
                if (voziloBaza == null)
                {
                    return BadRequest();
                }

                _context.Vozilo.Remove(voziloBaza);
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
