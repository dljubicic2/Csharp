using EdunovaWP1.Data;
using EdunovaWP1.Models;
using EdunovaWP1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace EdunovaWP1.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class VoziloController :ControllerBase
    {
        private readonly EdunovaContext _context;

        public VoziloController(EdunovaContext context)
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

        [HttpPost]
        public IActionResult Post(VoziloDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Vozilo v = new Vozilo()
                {
                    Model = dto.Model,
                    Marka = dto.Marka,
                    Pogon = dto.Pogon,
                    Kilometraza = dto.Kilometraza,
                    Godiste = dto.Godiste
                };

                _context.Vozilo.Add(v);
                _context.SaveChanges();

                dto.Sifra= v.Sifra;

                return Ok(dto);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
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
