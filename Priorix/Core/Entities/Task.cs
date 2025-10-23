using System;
using System.Collections.Generic;

namespace Priorix.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }

        // 🔹 Relação com o Usuário (responsável pela tarefa)
        public int ResponsibleUserId { get; set; }
        public User ResponsibleUser { get; set; } = default!;

        // 🔹 Relação com o Status
        public int StatusId { get; set; }
        public Statuses Statuses { get; set; } = default!;

        // 🔹 Relação com histórico e métricas
        public ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
        public ICollection<PriorizationMetrics> PriorizationMetrics { get; set; } = new List<PriorizationMetrics>();
    }
}
