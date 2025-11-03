using System;
using System.Collections.Generic;
using System.Linq;
using Priorix.Application.Dtos;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Core.Services
{
    public class PriorizationService : IPriorizationService
    {
        private readonly IPriorizationMetricsRepository _metricsRepo;
        private readonly ITaskRepository _taskRepo;

        public PriorizationService(IPriorizationMetricsRepository metricsRepo, ITaskRepository taskRepo)
        {
            _metricsRepo = metricsRepo;
            _taskRepo = taskRepo;
        }

        // ✅ Calcula e salva as métricas RICE
        public PriorizationMetrics CalculateAndSaveMetrics(int taskId, double reach, double impact, double confidence, double effort)
        {
            PriorizationMetrics metrics = new PriorizationMetrics
            {
                TaskId = taskId,
                Reach = reach,
                Impact = impact,
                Confidence = confidence,
                Effort = effort
            };

            // ✅ Corrigido nome do método
            metrics.CalculateAndSetRiceScore();

            _metricsRepo.Add(metrics);
            return metrics;
        }

        // 🔹 (Opcional) para uso futuro com DTO
        public PriorizationMetrics CalculateAndSaveMetrics(RiceInputDto input)
        {
            return CalculateAndSaveMetrics(input.TaskId, input.Reach, input.Impact, input.Confidence, input.Effort);
        }

        // ✅ Retorna tarefas priorizadas pelo RICE Score
        public IEnumerable<TaskEntity> GetPrioritizedTasks()
        {
            var metrics = _metricsRepo.GetAll().OrderByDescending(m => m.RiceScore).ToList();
            var tasks = _taskRepo.GetAll().ToList();

            var order = metrics.Select(m => m.TaskId).ToList();
            return tasks.OrderBy(t =>
            {
                var idx = order.IndexOf(t.Id);
                return idx < 0 ? int.MaxValue : idx;
            });
        }

        IEnumerable<System.Threading.Tasks.Task> IPriorizationService.GetPrioritizedTasks()
        {
            throw new NotImplementedException();
        }
    }
}
