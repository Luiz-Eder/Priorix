using System.Collections.Generic;

namespace Priorix.Core.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Task> Tasks { get; set; } = new();
    }
}
