using System.Collections.Generic;
using System.Linq;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Data.Context;

namespace Priorix.Data.Repositories
{
    public class TaskHistoryRepository : ITaskHistoryRepository
    {
        private readonly DataContext _context;

        public TaskHistoryRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(TaskHistory history)
        {
            _context.TaskHistories.Add(history);
            _context.SaveChanges();
        }

        public List<TaskHistory> GetByTaskId(int taskId)
        {
            return _context.TaskHistories
                .Where(h => h.TaskId == taskId)
                .OrderByDescending(h => h.ChangeDate)
                .ToList();
        }
    }
}
