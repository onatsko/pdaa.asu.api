using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pdaa.asu.api.Persistence;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pdaa.asu.api.Services.ViewModels;

namespace pdaa.asu.api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ZnoController : ControllerBase
    {
        private readonly ILogger<ZnoController> _logger;
        private readonly IUnitOfWork _uow;

        public ZnoController(ILogger<ZnoController> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [AllowAnonymous]
        [HttpGet("Exams")]
        public IActionResult GetZnoExams()
        {
            var exams = _uow.repoZno.GetZnoExams();
            var examsViewModels = new List<ZnoExamViewModel>();

            foreach (var exam in exams)
            {
                examsViewModels.Add(new ZnoExamViewModel()
                {
                    Id = exam.Id,
                    Name = exam.Name
                });
            }

            var result = JsonConvert.SerializeObject(examsViewModels);

            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet("Calculator")]
        public IActionResult GetZnoCalculator(
            [FromQuery] int year,
            [FromQuery] long exam1,
            [FromQuery] long exam2,
            [FromQuery] long exam3,
            [FromQuery] long exam4,
            [FromQuery] long exam5
            )
        {
            List<ZnoCalculatorResult> calculator = _uow.repoZno.GetZnoCalculator(year, exam1, exam2, exam3, exam4, exam5);

            foreach (var row in calculator)
            {
                var specForYearId = row.SpecForYearId;
                var spec = _uow.repoZno.GetSpec(specForYearId);
                row.Spec = spec;
            }
            var result = JsonConvert.SerializeObject(calculator);

            return Ok(result);

        }

    }
}
