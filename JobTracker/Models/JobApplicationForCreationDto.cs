using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class JobApplicationForCreationDto
    {
        public JobForCreationDto Job { get; set; }
        public DateTime InitialApplicationDate { get; set; } = DateTime.Now;
        public ApplicationStatus Status { get; set; }
    }
}
