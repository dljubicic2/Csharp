using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using teretana.Data;
using teretana.Models;

namespace teretana.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OpremaController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public OpremaController(EdunovaContext context)
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
                var oprema = _context.Oprema.ToList();
                if(oprema == null || oprema.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Oprema.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
            }
        }

        [HttpPost]
        public IActionResult Post(Oprema oprema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Oprema.Add(oprema);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Oprema oprema)
        {
            if(sifra <= 0 || oprema == null)
            {
                return BadRequest();
            }

            try
            {
                var opremaBaza = _context.Oprema.Find(sifra);
                if(opremaBaza == null)
                {
                    return BadRequest();
                }

                opremaBaza.Naziv = oprema.Naziv;
                opremaBaza.Namijena = oprema.Namijena;

                _context.Oprema.Update(opremaBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, opremaBaza);
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
            if (sifra <= 0)
            {
                return BadRequest();
            }
                var opremaBaza = _context.Oprema.Find(sifra);
                if(opremaBaza == null)
                {
                    return BadRequest();
                }
            try
            {
                _context.Oprema.Remove(opremaBaza);
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
