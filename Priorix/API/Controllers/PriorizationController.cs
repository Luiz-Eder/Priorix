using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Entities;
using Priorix.Application.Dtos; 

namespace Priorix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriorizationController : ControllerBase
    {
        private readonly IPriorizationService _priorizationService;

        public PriorizationController(IPriorizationService priorizationService)
        {
            _priorizationService = priorizationService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] RiceInputDto input)
        {
            if (input == null)
                return BadRequest("Dados inválidos");

            try
            {
                var result = _priorizationService.CalculateAndSaveMetrics(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ordered")]
        public IActionResult GetPrioritizedTasks()
        {
            var tasks = _priorizationService.GetPrioritizedTasks();
            return Ok(tasks);
        }
    }
}
