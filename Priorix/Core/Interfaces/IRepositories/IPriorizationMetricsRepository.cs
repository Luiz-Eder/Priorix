using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Repositories
{
    public interface IPriorizationMetricsRepository
    {
        void Add(PriorizationMetrics metrics);
        void Update(PriorizationMetrics metrics);
        PriorizationMetrics GetByTaskId(int taskId);
        IEnumerable<PriorizationMetrics> GetAll();
    }
}
