using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Repositories
{
    public interface ITaskHistoryRepository
    {
        void Add(TaskHistory history);
        List<TaskHistory> GetByTaskId(int taskId);
    }
}
