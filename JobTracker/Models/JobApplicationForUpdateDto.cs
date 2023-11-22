using JobTracker.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobTracker.Models
{
    public class JobApplicationForUpdateDto
    {
        public JobForUpdateDto Job { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
