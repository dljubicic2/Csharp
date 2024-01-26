using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using randomaplikacijazoloskivrt.Data;
using randomaplikacijazoloskivrt.Models;

namespace randomaplikacijazoloskivrt.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
 
    public class ProstorijaController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public ProstorijaController(EdunovaContext context)
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
                var prostorije = _context.Prostorija.ToList();
                if(prostorije == null || prostorije.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(_context.Prostorija.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
            }
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            if(sifra <= 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var p = _context.Prostorija.Find(sifra);

                if (p == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, p);
                }

                return new JsonResult(p);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Prostorija prostorija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Prostorija.Add(prostorija);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, prostorija);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Prostorija prostorija)
        {
            if(sifra <= 0 || prostorija == null)
            {
                return BadRequest();
            }

            try
            {
                var prostorijaBaza = _context.Prostorija.Find(sifra);
                if(prostorijaBaza == null)
                {
                    return BadRequest();
                }

                // Unošenje podataka

                prostorijaBaza.Dimenzije = prostorija.Dimenzije;
                prostorijaBaza.MaksBroj = prostorija.MaksBroj;
                prostorijaBaza.Mjesto = prostorija.Mjesto;

                _context.Prostorija.Update(prostorijaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, prostorijaBaza);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        public IActionResult Delete(int sifra)
        {
            if(sifra <= 0)
            {
                return BadRequest();
            }

            var prostorijaBaza = _context.Prostorija.Find(sifra);
            if(prostorijaBaza == null)
            {
                return BadRequest();
            }
            
            try
            {
                _context.Remove(prostorijaBaza);
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
