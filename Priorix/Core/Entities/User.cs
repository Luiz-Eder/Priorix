using System.Collections.Generic;

namespace Priorix.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual List<Task> Tasks { get; set; } = new List<Task>();
        public virtual List<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
    }
}
