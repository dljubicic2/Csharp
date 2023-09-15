using System.Text.RegularExpressions;
using EdunovaWP1.Data;
using EdunovaWP1.Models;
using EdunovaWP1.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace EdunovaWP1.Controllers
{
    /// <summary>
    /// Namjenjeno za CRUD operacije nad Upitom
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UpitController : ControllerBase
    {
        private readonly EdunovaContext _context;
        private readonly ILogger<UpitController> _logger;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>

        public UpitController(EdunovaContext context,
           ILogger<UpitController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Dohvaćam upite");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var upiti = _context.Upit
                    .Include(u => u.Osoba)
                    .ToList();

                if (upiti == null || upiti.Count == 0)
                {
                    return new EmptyResult();
                }

                List<UpitDTO> vrati = new();

                upiti.ForEach(u =>
                {
                    vrati.Add(new UpitDTO()
                    {
                        Sifra = u.Sifra,
                        Pitanje = u.Pitanje,
                 
                    });
                });
                return Ok(vrati);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex);
            }


        }
        [HttpPost]
        public IActionResult Post(UpitDTO upitDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (upitDTO.SifraOsoba <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var upit = _context.Upit.Find(upitDTO.SifraOsoba);

                if (upit == null)
                {
                    return BadRequest(ModelState);
                }

                Upit u = new()
                {
                    Pitanje = upitDTO.Pitanje,
                    
                    
                    
                };

                _context.Upit.Add(u);
                _context.SaveChanges();

                upitDTO.Sifra = u.Sifra;
                

                return Ok(upitDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status503ServiceUnavailable,
                   ex);
            }

        }
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, UpitDTO upitDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (sifra <= 0 || upitDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var osoba = _context.Osoba.Find(upitDTO.SifraOsoba);

                if (osoba == null)
                {
                    return BadRequest();
                }

                var upit = _context.Upit.Find(sifra);

                if (upit == null)
                {
                    return BadRequest();
                }

                upit.Pitanje = upitDTO.Pitanje;
                upit.Osoba = upitDTO.SifraOsoba;
                

                _context.Upit.Update(upit);
                _context.SaveChanges();

                upitDTO.Sifra = sifra;
                upitDTO.SifraOsoba = osoba.Sifra;

                return Ok(upitDTO);
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

            var upitBaza = _context.Upit.Find(sifra);
            if (upitBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Upit.Remove(upitBaza);
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
