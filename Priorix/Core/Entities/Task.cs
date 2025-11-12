using Priorix.Core.Services;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Priorix.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
<<<<<<< HEAD

=======
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }

<<<<<<< HEAD
        // 🔹 Relação com o Usuário (agora opcional)
        public int? ResponsibleUserId { get; set; }
=======
        // 🔹 Relação com o Usuário
        public int ResponsibleUserId { get; set; }
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956

        [JsonIgnore]
        public User? ResponsibleUser { get; set; }

<<<<<<< HEAD
        // 🔹 Relação com o Status (agora opcional)
        public int? StatusId { get; set; }
=======
        // 🔹 Relação com o Status
        public int StatusId { get; set; }
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956

        [JsonIgnore]
        public Status? Status { get; set; }

        // 🔹 Histórico e métricas
        public ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
        public ICollection<PriorizationMetrics> PriorizationMetrics { get; set; } = new List<PriorizationMetrics>();
    }
}
