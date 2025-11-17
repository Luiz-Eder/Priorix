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

        // ✅ GET /api/task
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var tasks = _taskService.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao buscar tarefas.",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        // ✅ GET /api/task/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id);
                if (task == null)
                    return NotFound(new { message = $"Tarefa com ID {id} não encontrada." });

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao buscar tarefa por ID.",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        // ✅ POST /api/task
        [HttpPost]
        public IActionResult Create([FromBody] TaskEntity task)
        {
            try
            {
                if (task == null)
                    return BadRequest(new { message = "O corpo da requisição está vazio." });

                _taskService.CreateTask(task);
                return Ok(task);
            }
            catch (Exception ex)
            {
                // 🔎 Retorna detalhes completos do erro (para debug local)
                return StatusCode(500, new
                {
                    message = "Erro ao criar tarefa.",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }
        }

        // ✅ PUT /api/task
        [HttpPut]
        public IActionResult Update([FromBody] TaskEntity task)
        {
            try
            {
                if (task == null)
                    return BadRequest(new { message = "O corpo da requisição está vazio." });

                _taskService.UpdateTask(task);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao atualizar tarefa.",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        // ✅ DELETE /api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok(new { message = $"Tarefa com ID {id} excluída com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Erro ao excluir tarefa.",
                    detail = ex.Message,    
                    inner = ex.InnerException?.Message
                });
            }
        }
    }
}
