using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teretana.Data;
using teretana.Extensions;
using teretana.Models;
using teretana.Models.DTO;


namespace teretana.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TreningController : ControllerBase
    {
        private readonly EdunovaContext _context;
        private readonly ILogger<TreningController> _logger;

        public TreningController(EdunovaContext context, ILogger<TreningController> logger)
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

            try
            {
                var treninzi = _context.Trening
                    .Include(t => t.Korisnici)
                    .Include(t => t.Oprema)
                    .ToList();

                if(treninzi == null || treninzi.Count == 0)
                {
                    return new EmptyResult();
                }
                return Ok(treninzi.MapTrening());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
                
            }
        }

        [HttpPost]
        public IActionResult Post(TreningDTO treningDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(treningDTO.SifraOprema <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var oprema = _context.Oprema.Find(treningDTO.SifraOprema);

                if(oprema == null)
                {
                    return BadRequest(ModelState);
                }

                Trening t = new()
                {
                    Naziv = treningDTO.Naziv,
                    BrojPonavljanja = treningDTO.BrojPonavljanja,
                    BrojSerija = treningDTO.BrojSerija
                };

                _context.Trening.Add(t);
                _context.SaveChanges();

                treningDTO.Sifra = t.Sifra;
                treningDTO.Oprema = oprema.Naziv;

                return Ok(treningDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
                
            }
        }
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, TreningDTO treningDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(sifra <= 0 || treningDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var oprema = _context.Oprema.Find(treningDTO.SifraOprema);

                if(oprema == null)
                {
                    return BadRequest();
                }

                var trening = _context.Trening.Find(sifra);

                if(trening == null)
                {
                    return BadRequest();
                }

                trening.Naziv = treningDTO.Naziv;
                trening.Oprema = oprema;
                trening.BrojSerija = treningDTO.BrojSerija;
                trening.BrojPonavljanja = treningDTO.BrojPonavljanja;

                _context.Trening.Update(trening);
                _context.SaveChanges();

                treningDTO.Sifra = sifra;
                treningDTO.Oprema = oprema.Naziv;

                return Ok(treningDTO);
                
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var treningBaza = _context.Trening.Find(sifra);
            if(treningBaza == null)
            {
                return BadRequest();
            }
            
            try
            {
                _context.Trening.Remove(treningBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {
                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");
                
            }
        }

        [HttpGet]
        [Route("{sifra:int}/korisnici")]
        public IActionResult GetKorisnici(int sifra)
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
                var trening = _context.Trening
                .Include(k => k.Korisnici)
                .FirstOrDefault(k => k.Sifra == sifra);

                if (trening == null)
                {
                    return BadRequest();
                }

                if (trening.Korisnici == null || trening.Korisnici.Count == 0)
                {
                    return new EmptyResult();
                }

                List<KorisnikDTO> vrati = new();
                trening.Korisnici.ForEach(k =>
                {
                    vrati.Add(new KorisnikDTO()
                    {
                        Sifra = k.Sifra,
                        Ime = k.Ime,
                        Prezime = k.Prezime,
                        BrojIskaznice = k.BrojIskaznice
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
        [Route("{sifra:int}/dodaj/{korisnikSifra:int}")]
        public IActionResult DodajKorisnika(int sifra, int korisnikSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(sifra <= 0 || korisnikSifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var trening = _context.Trening
                    .Include(k => k.Korisnici)
                    .FirstOrDefault(k => k.Sifra == sifra);

                if(trening == null)
                {
                    return BadRequest();
                }

                var korisnik = _context.Korisnik.Find(korisnikSifra);

                if(korisnik == null)
                {
                    return BadRequest();
                }

                trening.Korisnici.Add(korisnik);

                _context.Trening.Update(trening);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{sifra:int}/obrisi/{korisnikSifra:int}")]
        public IActionResult ObrisiKorisnika(int sifra, int korisnikSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(sifra <= 0 || korisnikSifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var trening = _context.Trening
                    .Include(t => t.Korisnici)
                    .FirstOrDefault(t => t.Sifra == sifra);

                if(trening == null)
                {
                    return BadRequest();
                }

                var korisnik = _context.Korisnik.Find(korisnikSifra);

                if(korisnik == null)
                {
                    return BadRequest();
                }

                trening.Korisnici.Remove(korisnik);

                _context.Trening.Update(trening);
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
