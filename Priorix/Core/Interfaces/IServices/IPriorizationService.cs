using System.Collections.Generic;
using Priorix.Core.Entities;
using Priorix.Application.Dtos; // DTO que você criou

namespace Priorix.Core.Interfaces.Services
{
    public interface IPriorizationService
    {
        // Corrigido: agora usa a classe existente 'PriorizationMetrics'
        PriorizationMetrics CalculateAndSaveMetrics(RiceInputDto input);

        // Retorna a lista de tarefas priorizadas
        IEnumerable<System.Threading.Tasks.Task> GetPrioritizedTasks();
    }
}
