using System.ComponentModel.DataAnnotations;

namespace Priorix.Application.Dtos
{
    public class RiceInputDto
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Reach { get; set; }

        [Required]
        [Range(0.25, 3.0)]
        public double Impact { get; set; }

        [Required]
        [Range(0.0, 1.0)]
        public double Confidence { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)] // Esforço não pode ser zero
        public double Effort { get; set; }
    }
}