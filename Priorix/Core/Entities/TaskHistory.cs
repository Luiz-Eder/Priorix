using System;

namespace Priorix.Core.Entities
{
    public class TaskHistory
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Action { get; set; } = string.Empty;

        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;

        public int? ChangedByUserId { get; set; }
        public User? ChangedByUser { get; set; }

        public Task? Task { get; set; }
    }
}
