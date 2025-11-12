using System.Collections.Generic;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Core.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskEntity> GetAll();
        TaskEntity GetById(int id);
        void Add(TaskEntity task);
        void Update(TaskEntity task);
        void Delete(int id);
        bool Exists(int id);
        void Add(Task task);
        void Update(Task task);
    }
}
