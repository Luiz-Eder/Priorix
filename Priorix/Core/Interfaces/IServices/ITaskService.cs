using System.Collections.Generic;
using Priorix.Core.Entities;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Core.Interfaces.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskEntity> GetAllTasks();
        TaskEntity GetTaskById(int id);
        void CreateTask(TaskEntity task);
        void UpdateTask(TaskEntity task);
        void DeleteTask(int id);
        void CreateTask(System.Threading.Tasks.Task task);
        void UpdateTask(System.Threading.Tasks.Task task);
    }
}
