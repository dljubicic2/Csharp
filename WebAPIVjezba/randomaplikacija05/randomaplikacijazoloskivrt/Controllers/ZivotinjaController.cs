using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Post(ZivotinjaDTO zivotinjaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(zivotinjaDTO.SifraProstora <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var prostorija = _context.Prostorija.Find(zivotinjaDTO.SifraProstora);

                if(prostorija == null)
                {
                    return BadRequest(ModelState);
                }

                Prostorija p = new()
                {
                    
                };
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

