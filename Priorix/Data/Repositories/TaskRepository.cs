using System.Collections.Generic;
using System.Linq;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Data.Context;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskEntity> GetAll() => _context.Tasks.ToList();

        public TaskEntity GetById(int id) => _context.Tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TaskEntity task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(TaskEntity task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id) => _context.Tasks.Any(t => t.Id == id);

        public void Add(System.Threading.Tasks.Task task)
        {
            throw new NotImplementedException();
        }

        public void Update(System.Threading.Tasks.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
