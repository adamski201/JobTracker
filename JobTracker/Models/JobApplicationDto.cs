using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class JobApplicationDto
    {
        public int Id { get; set; }
        public JobDto Job { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
