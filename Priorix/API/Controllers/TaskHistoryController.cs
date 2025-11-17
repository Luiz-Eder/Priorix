using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Services;

namespace Priorix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskHistoryController : ControllerBase
    {
        private readonly ITaskHistoryService _service;

        public TaskHistoryController(ITaskHistoryService service)
        {
            _service = service;
        }

        [HttpGet("{taskId}")]
        public IActionResult GetByTask(int taskId)
        {
            var history = _service.GetByTaskId(taskId);
            return Ok(history);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TaskHistory history)
        {
            if (history == null) return BadRequest();
            _service.AddHistory(history);
            return Ok(history);
        }
    }
}
