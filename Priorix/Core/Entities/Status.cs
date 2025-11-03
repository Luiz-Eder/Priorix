using System.Collections.Generic;

namespace Priorix.Core.Entities
{
    public class Statuse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual List<Task> Tasks { get; set; } = new List<Task>();
    }
}
