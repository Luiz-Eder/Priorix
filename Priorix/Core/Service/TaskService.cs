using System;
using System.Collections.Generic;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // ✅ Retorna uma lista da entidade Task (não System.Threading.Tasks.Task)
        public IEnumerable<TaskEntity> GetAllTasks() => _taskRepository.GetAll();

        // ✅ Busca uma task específica
        public TaskEntity GetTaskById(int id) => _taskRepository.GetById(id);

        // ✅ Cria uma nova task
        public void CreateTask(TaskEntity task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "A tarefa não pode ser nula.");

            _taskRepository.Add(task);
        }

        // ✅ Atualiza uma task existente
        public void UpdateTask(TaskEntity task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "A tarefa não pode ser nula.");

            _taskRepository.Update(task);
        }

        // ✅ Deleta uma task pelo ID
        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }

        IEnumerable<System.Threading.Tasks.Task> ITaskService.GetAllTasks()
        {
            throw new NotImplementedException();
        }

        System.Threading.Tasks.Task ITaskService.GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateTask(System.Threading.Tasks.Task task)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(System.Threading.Tasks.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
