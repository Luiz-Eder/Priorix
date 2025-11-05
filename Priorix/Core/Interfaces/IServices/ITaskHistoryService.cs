using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Services
{
    public interface ITaskHistoryService
    {
        void AddHistory(TaskHistory history);
        List<TaskHistory> GetByTaskId(int taskId);
    }
}
