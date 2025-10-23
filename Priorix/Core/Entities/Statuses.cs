using System.Collections.Generic;

namespace Priorix.Core.Entities
{
    public class Statuses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Task> Tasks { get; set; } = new List<Task>();
    }
}
