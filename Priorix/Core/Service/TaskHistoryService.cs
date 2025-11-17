using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Interfaces.Repositories;

namespace Priorix.Core.Services
{
    public class TaskHistoryService : ITaskHistoryService
    {
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TaskHistoryService(ITaskHistoryRepository taskHistoryRepository)
        {
            _taskHistoryRepository = taskHistoryRepository;
        }

        public void AddHistory(TaskHistory history)
        {
            _taskHistoryRepository.Add(history);
        }

        public List<TaskHistory> GetByTaskId(int taskId)
        {
            return _taskHistoryRepository.GetByTaskId(taskId);
        }
    }
}
