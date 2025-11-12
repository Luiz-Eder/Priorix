using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Data.Context;

namespace Priorix.Data.Repositories
{
    public class PriorizationMetricsRepository : IPriorizationMetricsRepository
    {
        private readonly DataContext _context;

        public PriorizationMetricsRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(PriorizationMetrics metrics)
        {
            _context.PriorizationMetrics.Add(metrics);
            _context.SaveChanges();
        }

        public void Update(PriorizationMetrics metrics)
        {
            _context.Attach(metrics).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public PriorizationMetrics GetByTaskId(int taskId) => _context.PriorizationMetrics.FirstOrDefault(m => m.TaskId == taskId);

        public IEnumerable<PriorizationMetrics> GetAll()
        {
            return _context.PriorizationMetrics.AsNoTracking().ToList();
        }
    }
}
