using System.Collections.Generic;
using Priorix.Core.Entities;
using Priorix.Application.Dtos;
using Task = Priorix.Core.Entities.Task;

namespace Priorix.Core.Interfaces.Services
{
    public interface IPriorizationService
    {
        PriorizationMetrics CalculateAndSaveMetrics(RiceInputDto input);
        IEnumerable<Task> GetPrioritizedTasks();
    }
}
