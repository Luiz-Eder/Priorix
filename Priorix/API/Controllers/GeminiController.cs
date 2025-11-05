using Microsoft.AspNetCore.Mvc;
using Priorix.Application.DTOs;
using Priorix.Core.Services;
using System.Threading.Tasks;

namespace Priorix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeminiController : ControllerBase
    {
        private readonly GeminiService _geminiService;

        public GeminiController(GeminiService geminiService)
        {
            _geminiService = geminiService;
        }

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze([FromBody] AIRequestDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Title))
                return BadRequest("Informe o título e a descrição da tarefa.");

            var result = await _geminiService.AnalyzeTaskAsync(dto.Title, dto.Description);
            return Ok(result);
        }
    }
}
