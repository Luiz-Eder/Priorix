using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Services
{
    public interface ITaskService
    {
        IEnumerable<System.Threading.Tasks.Task> GetAllTasks();
        System.Threading.Tasks.Task GetTaskById(int id);
        void CreateTask(System.Threading.Tasks.Task task);
        void UpdateTask(System.Threading.Tasks.Task task);
        void DeleteTask(int id);
    }
}
