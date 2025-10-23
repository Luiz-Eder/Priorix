namespace Priorix.Core.Entities
{
    public class PriorizationMetrics
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public double Reach { get; set; }
        public double Impact { get; set; }
        public double Confidence { get; set; }
        public double Effort { get; set; }
        public double RiceScore { get; set; }

        public Task Task { get; set; }

        public void CalculateRiceScore()
        {
            RiceScore = (Reach * Impact * Confidence) / Effort;
        }
    }
}
