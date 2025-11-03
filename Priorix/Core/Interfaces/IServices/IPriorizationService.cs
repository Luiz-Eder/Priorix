using System.Collections.Generic;
using Priorix.Core.Entities;
using Priorix.Application.Dtos; 

namespace Priorix.Core.Interfaces.Services
{
    public interface IPriorizationService
    {
        PriorizationMetrics CalculateAndSaveMetrics(RiceInputDto input);

        IEnumerable<System.Threading.Tasks.Task> GetPrioritizedTasks();
    }
}
