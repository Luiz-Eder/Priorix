using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Entities;
using Priorix.Application.Dtos; // Importe o DTO

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
        // 1. Corrigido: Recebe o DTO, não a Entidade
        public IActionResult Calculate([FromBody] RiceInputDto input)
        {
            if (input == null)
                return BadRequest("Dados inválidos");

            try
            {
                // 2. Corrigido: Apenas passa o DTO para o serviço
                var result = _priorizationService.CalculateAndSaveMetrics(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Retorna um erro caso o serviço falhe (ex: TaskId não existe)
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