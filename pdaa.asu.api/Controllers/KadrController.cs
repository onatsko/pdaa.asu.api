﻿using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pdaa.asu.api.Persistence;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pdaa.asu.api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class KadrController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<KadrController> _logger;
        private readonly IUnitOfWork _uow;

        public KadrController(ILogger<KadrController> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [AllowAnonymous]
        [HttpGet("FullName")]
        public IActionResult GetKadrFullName([FromQuery]long kadrId)
        {
            if (kadrId <= 0)
                return BadRequest();

            var kadr = _uow.repoKadr.Get(kadrId);
            if (kadr == null)
                return NotFound();

            var result = JsonConvert.SerializeObject(kadr.NameFull);

            return Ok(result);

        }

        [HttpGet("Name")]
        public IActionResult GetKadrName([FromQuery]long kadrId)
        {
            var nameIdentifier = this.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (kadrId <= 0)
                return BadRequest();

            var kadr = _uow.repoKadr.Get(kadrId);
            if (kadr == null)
                return NotFound();

            var result = JsonConvert.SerializeObject(kadr.NameFull);

            return Ok(result);

        }

    }
}
