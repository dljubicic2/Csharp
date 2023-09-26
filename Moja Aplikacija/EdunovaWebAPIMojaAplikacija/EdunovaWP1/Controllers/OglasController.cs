using System.Text.RegularExpressions;
using EdunovaWP1.Data;
using EdunovaWP1.Models;
using EdunovaWP1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdunovaWP1.Controllers
{
    /// <summary>
    /// Namjenjena za CRUD operacije nad Oglasom
    /// </summary>

    [ApiController]
    [Route("api/v1/[controller]")]
    public class OglasController : ControllerBase
    {
        private readonly EdunovaContext _context;
        private readonly ILogger<OglasController> _logger;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>

        public OglasController(EdunovaContext context, 
            ILogger<OglasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Dohvaćam oglase");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var oglasi = _context.Oglas
                    .Include(og => og.Osoba)
                    .ToList();

                if(oglasi == null || oglasi.Count == 0)
                {
                    return new EmptyResult();
                }

                List<OglasDTO> vrati = new();

                oglasi.ForEach(og =>
                {
                    vrati.Add(new OglasDTO()
                    {
                        Sifra = og.Sifra,
                        Naslov = og.Naslov,
                        Opis = og.Opis,
                        Cijena = og.Cijena,
                        Osoba = og.Osoba?.Nadimak,
                        SifraOsoba = og.Osoba.Sifra
                    });
                });

                return Ok(vrati);
                    
                
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
                
            }            
            
        }

        [HttpPost]
        public IActionResult Post(OglasDTO oglasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (oglasDTO.SifraOsoba <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var osoba = _context.Osoba.Find(oglasDTO.SifraOsoba);

                if (osoba == null)
                {
                    return BadRequest(ModelState);
                }

                Oglas og = new()
                {
                    Naslov = oglasDTO.Naslov,
                    Opis = oglasDTO.Naslov,
                    Cijena = oglasDTO.Cijena,
                    Osoba = osoba
                };

                _context.Oglas.Add(og);
                _context.SaveChanges();

                oglasDTO.Sifra = og.Sifra;
                oglasDTO.Osoba = osoba.Nadimak;

                return Ok(oglasDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);

            }
        }
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, OglasDTO oglasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (sifra <= 0 || oglasDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var vozilo = _context.Oglas.Find(oglasDTO.SifraOsoba);

                if (vozilo == null)
                {
                    return BadRequest();
                }

                var oglas = _context.Oglas.Find(sifra);

                if (oglas == null)
                {
                    return BadRequest();
                }

                oglas.Naslov = oglasDTO.Naslov;
                oglas.Opis = oglasDTO.Opis;
                oglas.Cijena = oglasDTO.Cijena;

                _context.Oglas.Update(oglas);
                _context.SaveChanges();

                oglasDTO.Sifra = sifra;
                

                return Ok(oglasDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
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

            var oglasBaza = _context.Oglas.Find(sifra);
            if (oglasBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Oglas.Remove(oglasBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");

            }
        }
    }
    
}
