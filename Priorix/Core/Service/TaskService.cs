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

        public IEnumerable<TaskEntity> GetAllTasks() => _taskRepository.GetAll();

        public TaskEntity GetTaskById(int id) => _taskRepository.GetById(id);

        public void CreateTask(TaskEntity task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "A tarefa não pode ser nula.");

            _taskRepository.Add(task);
        }

        public void UpdateTask(TaskEntity task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "A tarefa não pode ser nula.");

            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
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
