using Microsoft.AspNetCore.Mvc;
using RandomAplikacija01.Data;
using RandomAplikacija01.Models;

namespace RandomAplikacija01.Controllers
{
    [ApiController]
    [Route("Api/v1/[controller]")]


    public class KupacController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public KupacController(EdunovaContext context)
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

            return Ok();




        }
    }
}
