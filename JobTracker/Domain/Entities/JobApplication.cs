using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JobTracker.Domain.Entities
{
    public class JobApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Job Job { get; set; }
        [Required]
        public Company Employer { get; set; }
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
        public DateTime InitialDateAdvertised { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public DateTime Deadline { get; set; }
        public ApplicationStatus Status { get; set; }
    }

    public enum ApplicationStatus
    {
        Interested,
        Applied,
        Interviewing,
        Rejected,
        Success
    }
}
