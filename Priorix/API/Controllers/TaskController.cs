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

        // ✅ POST /api/task (VERSÃO BLINDADA)
        // Substitua o método Create antigo por este:
        // POST: api/Task
        [HttpPost]
        public IActionResult Create([FromBody] TaskEntity task)
        {
            try
            {
                if (task == null)
                    return BadRequest(new { message = "O corpo da requisição está vazio." });

                // --- CORREÇÃO DE DADOS (BLINDAGEM) ---

                // 1. Se o Usuário for 0 (erro do front), forçamos NULL
                if (task.ResponsibleUserId == 0)
                {
                    task.ResponsibleUserId = null;
                }

                // 2. Se a Prioridade for 0, forçamos 1 (Baixa)
                if (task.Priority == 0)
                {
                    task.Priority = 1;
                }

                // 3. Garante que o ID da tarefa seja 0 para o banco criar um novo
                task.Id = 0;
                // -------------------------------------

                _taskService.CreateTask(task);
                return Ok(task);
            }
            catch (Exception ex)
            {
                // Este log vai te mostrar o erro exato no console do navegador
                return StatusCode(500, new
                {
                    message = "Erro interno ao salvar tarefa.",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message
                });
            }
        }

        // ✅ PUT /api/task (VERSÃO BLINDADA)
        [HttpPut]
        public IActionResult Update([FromBody] TaskEntity task)
        {
            try
            {
                if (task == null)
                    return BadRequest(new { message = "O corpo da requisição está vazio." });

                // --- PROTEÇÃO CONTRA DADOS INVÁLIDOS (IGUAL AO CREATE) ---

                // 1. Se vier Usuário 0, força NULL
                if (task.ResponsibleUserId == 0)
                {
                    task.ResponsibleUserId = null;
                }

                // 2. Se vier Prioridade 0, força 1 (Baixa)
                if (task.Priority == 0)
                {
                    task.Priority = 1;
                }

                // 3. Proteção Extra: Status nunca pode ser 0
                if (task.StatusId == 0)
                {
                    // Se por algum milagre vier 0, retorna erro ou define um padrão.
                    // Aqui vamos assumir erro, pois tarefa sem status no Kanban é grave.
                    return BadRequest(new { message = "A tarefa precisa ter um Status válido." });
                }
                // ---------------------------------------

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
