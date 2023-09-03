using EdunovaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller])")]
    public class SmjerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var lista = new List<Smjer>()
            {
                new () {Naziv = "prvi"},
                new () {Naziv = "drugi"}
            };
            return new JsonResult(lista);
        }
    }
}
