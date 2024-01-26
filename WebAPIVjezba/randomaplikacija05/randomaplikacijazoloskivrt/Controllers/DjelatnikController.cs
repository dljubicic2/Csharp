using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using randomaplikacijazoloskivrt.Data;
using randomaplikacijazoloskivrt.Models;

namespace randomaplikacijazoloskivrt.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
 
    public class DjelatnikController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public DjelatnikController(EdunovaContext context)
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
                var djelatnici = _context.Djelatnik.ToList();
                if(djelatnici == null || djelatnici.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(_context.Djelatnik.ToList());
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
            if (sifra <= 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var d = _context.Djelatnik.Find(sifra);

                if(d == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, d);
                }

                return new JsonResult(d);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
            } 
        }

        [HttpPost]
        public IActionResult Post(Djelatnik djelatnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Djelatnik.Add(djelatnik);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, djelatnik);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Djelatnik djelatnik)
        {
            if(sifra <= 0 || djelatnik == null)
            {
                return BadRequest();
            }

            try
            {
                var djelatnikBaza = _context.Djelatnik.Find(sifra);
                if(djelatnikBaza == null)
                {
                    return BadRequest();
                }

                // Unošenje podataka

                djelatnikBaza.Ime = djelatnik.Ime;
                djelatnikBaza.Prezime = djelatnik.Prezime;
                djelatnikBaza.Oib = djelatnik.Oib;

                _context.Djelatnik.Update(djelatnikBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, djelatnikBaza);
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

            var djelatnikBaza = _context.Djelatnik.Find(sifra);
            if(djelatnikBaza == null)
            {
                return BadRequest();
            }
            
            try
            {
                _context.Remove(djelatnikBaza);
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
