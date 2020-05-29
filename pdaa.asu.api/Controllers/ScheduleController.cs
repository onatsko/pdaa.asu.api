using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pdaa.asu.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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
