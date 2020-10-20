using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace pdaa.asu.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(ILogger<ScheduleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetScheduleForKadrAsync(long kadrId, int weekNum)
        {

            return Ok(kadrId);

        }

    }
}
