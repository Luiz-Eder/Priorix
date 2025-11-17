using System.ComponentModel.DataAnnotations.Schema;

namespace Priorix.Core.Entities
{
    public class PriorizationMetrics
    {
        public int Id { get; set; }
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public Task? Task { get; set; } 

        public double Reach { get; set; }
        public double Impact { get; set; }
        public double Confidence { get; set; }
        public double Effort { get; set; }
        public double RiceScore { get; set; }

        public void CalculateAndSetRiceScore()
        {
            if (Effort <= 0) Effort = 1; 
            RiceScore = (Reach * Impact * Confidence) / Effort;
        }
    }
}
