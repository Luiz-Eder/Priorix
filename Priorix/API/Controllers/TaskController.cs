using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Interfaces.Services;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskEntity task)
        {
            _taskService.CreateTask(task);
            return Ok(task);
        }

        [HttpPut]
        public IActionResult Update([FromBody] TaskEntity task)
        {
            _taskService.UpdateTask(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
