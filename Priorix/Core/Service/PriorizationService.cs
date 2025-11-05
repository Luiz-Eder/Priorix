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

        public PriorizationMetrics CalculateAndSaveMetrics(int taskId, double reach, double impact, double confidence, double effort)
        {
            var metrics = new PriorizationMetrics
            {
                TaskId = taskId,
                Reach = reach,
                Impact = impact,
                Confidence = confidence,
                Effort = effort
            };

            metrics.CalculateAndSetRiceScore(); 

            _metricsRepo.Add(metrics);
            return metrics;
        }

        public PriorizationMetrics CalculateAndSaveMetrics(RiceInputDto input)
        {
            return CalculateAndSaveMetrics(input.TaskId, input.Reach, input.Impact, input.Confidence, input.Effort);
        }

        public IEnumerable<TaskEntity> GetPrioritizedTasks()
        {
            var metrics = _metricsRepo.GetAll()
                                      .OrderByDescending(m => m.RiceScore)
                                      .ToList();

            var tasks = _taskRepo.GetAll().ToList();

            var orderedTasks = tasks.OrderBy(t =>
            {
                var idx = metrics.FindIndex(m => m.TaskId == t.Id);
                return idx == -1 ? int.MaxValue : idx;
            }).ToList();

            return orderedTasks;
        }
    }
}
