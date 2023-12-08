using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using randomaplikacijazoloskivrt.Data;

namespace randomaplikacijazoloskivrt.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class DjelatnikController : ControllerBase
    {
        private readonly EdunovaContext _context;

        public DjelatnikController(EdunovaContext context)
        {
            _context = context;
        }
    }


}
