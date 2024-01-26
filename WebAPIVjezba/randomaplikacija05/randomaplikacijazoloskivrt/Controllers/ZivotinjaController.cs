using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using randomaplikacijazoloskivrt.Data;
using randomaplikacijazoloskivrt.Models;
using randomaplikacijazoloskivrt.Models.DTO;

namespace randomaplikacijazoloskivrt.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class Zivotinja : ControllerBase
    {
        private readonly EdunovaContext _context;
        public Zivotinja(EdunovaContext context)
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
                var zivotinje = _context.Zivotinja.ToList();
                if (zivotinje == null || zivotinje.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(_context.Zivotinja.ToList());
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
                var z = _context.Zivotinja.Find(sifra);

                if(z == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, z);
                }

                return new JsonResult(z);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpPost]
       public IActionResult Post(ZivotinjaDTO zivotinjaDTO)
        
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(zivotinjaDTO.BrojDjelatnika <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var djelatnik = _context.Djelatnik.Find(zivotinjaDTO.BrojDjelatnika);

                if(djelatnik == null)
                {
                    return BadRequest(ModelState);
                }

            

                return Ok(zivotinjaDTO);
               
            }
            catch (Exception ex)
            {

                StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }

        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, ZivotinjaDTO zivotinjaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(sifra <= 0 || zivotinjaDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var prostorija = _context.Prostorija.Find(zivotinjaDTO.SifraProstora);

                if(prostorija == null)
                {
                    return BadRequest();
                }

                var zivotinja = _context.Zivotinja.Find(sifra);

                if(zivotinja == null)
                {
                    return BadRequest();
                }

                zivotinja.Vrsta = zivotinjaDTO.Vrsta;
                zivotinja.Naziv = zivotinjaDTO.Naziv;

                _context.Zivotinja.Update(zivotinja);
                _context.SaveChanges();

                zivotinjaDTO.Prostorija = prostorija.Dimenzije;
                zivotinjaDTO.Sifra = sifra;
               

                return Ok(zivotinjaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);

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

            var zivotinjaBaza = _context.Zivotinja.Find(sifra);

            if (zivotinjaBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Zivotinja.Remove(zivotinjaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");
            }
        }


        [HttpGet]
        [Route("{sifra:int}/prostorije")]
        public IActionResult GetProstorije(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var zivotinja = _context.Zivotinja
                    .Include(z => z.Prostorije)
                    .FirstOrDefault(z => z.Sifra == sifra);

                if(zivotinja == null)
                {
                    return BadRequest();
                }

                if (zivotinja.Prostorije == null || zivotinja.Prostorije.Count == 0)
                {
                    return new EmptyResult();
                }

                List<ProstorijaDTO> vrati = new();
                zivotinja.Prostorije.ForEach(p =>
                {
                    vrati.Add(new ProstorijaDTO()
                    {
                        Sifra = p.Sifra,
                        Dimenzije = p.Dimenzije,
                        MaksBroj = p.MaksBroj,
                        Mjesto = p.Mjesto

                    });
                });

                return Ok(vrati);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
            }
        }

        [HttpPost]
        [Route("{sifra:int}/dodaj/{sifraProstora:int}")]
        public IActionResult DodajProstor(int sifra, int sifraProstora)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (sifra <= 0 || sifraProstora <= 0)
            {
                return BadRequest();
            }

            try
            {
                var zivotinja = _context.Zivotinja
                    .Include(z => z.Prostorije)
                    .FirstOrDefault(z => z.Sifra == sifra);

                if (zivotinja == null)
                {
                    return BadRequest();
                }

                var prostorija = _context.Prostorija.Find(sifraProstora);

                if (prostorija == null)
                {
                    return BadRequest();
                }

                zivotinja.Prostorije.Add(prostorija);

                _context.Zivotinja.Update(zivotinja);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}/obrisi/{sifraProstora:int}")]
        public IActionResult ObrisiProstor(int sifra, int sifraProstora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(sifra <= 0 || sifraProstora <= 0)
            {
                return BadRequest();
            }

            try
            {
                var zivotinja = _context.Zivotinja
                    .Include(z => z.Prostorije)
                    .FirstOrDefault(z => z.Sifra == sifra);

                if(zivotinja == null)
                {
                    return BadRequest();
                }

                var prostorija = _context.Prostorija.Find(sifraProstora);

                if(prostorija == null)
                {
                    return BadRequest();
                }

                zivotinja.Prostorije.Remove(prostorija);

                _context.Zivotinja.Update(zivotinja);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
                
            }
        }

    }
}

