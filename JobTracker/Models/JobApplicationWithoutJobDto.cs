using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class JobApplicationWithoutJobDto
    {
        public int Id { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
