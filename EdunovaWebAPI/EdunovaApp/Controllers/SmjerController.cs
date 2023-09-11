using EdunovaApp.Data;
using EdunovaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EdunovaApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller])")]
    public class SmjerController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public SmjerController(EdunovaContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
           // Kontrola u koliko upit nije dobar
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var smjerovi = _context.Smjer.ToList();
                if(smjerovi==null || smjerovi.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(_context.Smjer.ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                                                               ex.Message);
            }

            
        }

        [HttpPost]
        public IActionResult Post(Smjer smjer)
        {
           

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Smjer.Add(smjer);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, smjer);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                                              ex.Message);
            }


            
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(Smjer smjer, int sifra)
        {
            // Promjena u bazi
            if (sifra <= 0 || smjer==null)
            {
                return BadRequest();
            }
            try
            {
                var smjerBaza = _context.Smjer.Find(sifra);
                if (smjerBaza == null)
                {
                    return BadRequest();
                }
                smjerBaza.Naziv = smjer.Naziv;
                smjerBaza.Trajanje = smjer.Trajanje;
                smjerBaza.Cijena = smjer.Cijena;
                smjerBaza.Upisnina=smjer.Upisnina;
                smjerBaza.Verificiran = smjer.Verificiran;

                _context.Smjer.Update(smjerBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, smjerBaza);
            }
            catch(Exception ex)
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
                var smjerBaza = _context.Smjer.Find(sifra);
                if (smjerBaza == null)
                {
                    return BadRequest();
                }

                _context.Smjer.Remove(smjerBaza);
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
